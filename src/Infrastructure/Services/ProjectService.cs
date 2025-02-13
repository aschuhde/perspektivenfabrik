using Application.Filter;
using Application.Models.ProjectService;
using Application.Selectors;
using Application.Services;
using Application.Updaters;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Data;
using Infrastructure.Data.DbEntities;
using Infrastructure.Data.DbLoading;
using Infrastructure.Data.Mapping;
using Infrastructure.FilterExtensions;
using Infrastructure.ResultExtensions;
using Infrastructure.SelectorExtensions;
using Infrastructure.Tools;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Services;

public class ProjectService(ApplicationDbContext dbContext, ILogger<ProjectService> logger) : IProjectService
{
    private async Task<ProjectDto[]> GetProjects(Func<IQueryable<DbProject>, IQueryable<DbProject>> filterFunction, Func<IQueryable<DbProject>, IQueryable<DbProject>> selectFunction, CancellationToken ct)
    {
        var query = selectFunction(filterFunction(dbContext.Projects.IncludeFull())).AsNoTracking();
        #if DEBUG
        var queryString = query.ToQueryString();
        #endif
        return (await query.ToArrayAsync(ct)).Select(x => x.ToProject()).ToArray();
    }

    public async Task<ProjectDto[]> GetPublicProjects(ProjectFilter? projectFilter, ProjectSelector? projectSelector, CancellationToken ct)
    {
        return await GetProjects(query =>
            (projectFilter ?? EmptyFilterCreator.CreateEmptyProjectFilter()).Filter(query.Where(x =>
                x.Visibility == ProjectVisibility.Public)), query => 
            (projectSelector ?? DefaultSelectorCreator.CreateDefaultProjectSelector()).Select(query), ct);
    }
    
    public async Task<ProjectDto?> GetProjectById(Guid entityId, CancellationToken ct)
    {
        return (await GetProjects(query => query.Where(x => x.EntityId == entityId), query => query, ct))
            .FirstOrDefault();
    }
    
    private void UpdateRelatedEntityWithHistory<T1, T2>(T1? entity, T1? existingEntity, Func<T1, T2> onGetDbEntity) 
        where T1 : BaseEntityDto where T2 : class
    {
        if (existingEntity == null && entity == null)
        {
            return;
        }
        UpdateHistory(entity?.History, existingEntity?.History);
        if (existingEntity == null)
        {
            dbContext.Add(onGetDbEntity(entity!));    
        }
        else
        {
            if (entity == null || entity.EntityId != existingEntity.EntityId)
            {
                dbContext.Remove(onGetDbEntity(existingEntity));
            }
            else
            {
                dbContext.Update(onGetDbEntity(entity));
            }
        }
    }

    private void UpdateHistoryItems(ModificationHistoryDto? history, ModificationHistoryDto? existingHistory)
    {
        var historyItems = history?.HistoryItems ?? [];
        var existingHistoryItems = existingHistory?.HistoryItems ?? [];
        foreach (var historyItem in historyItems)
        {
            var existingHistoryItem = existingHistoryItems.FirstOrDefault(x => x.EntityId == historyItem.EntityId);

            if (existingHistoryItem == null)
            {
                dbContext.Add(historyItem.ToDbHistoryItem(history!));    
            }
            else
            {
                dbContext.Update(historyItem.ToDbHistoryItem(history!));
            }
        }
        foreach (var existingHistoryItem in existingHistoryItems)
        {
            if (historyItems.All(x => x.EntityId != existingHistoryItem.EntityId))
            {
                dbContext.Remove(existingHistoryItem.ToDbHistoryItem(existingHistory!));
            }
        }
    }
    private void UpdateHistory(ModificationHistoryDto? history, ModificationHistoryDto? existingHistory)
    {
        if (history == null && existingHistory == null)
        {
            return;
        }
        //UpdateHistoryItems(history, existingHistory);
        if (history == null)
        {
            dbContext.Remove(existingHistory!.ToDbHistory());
            return;
        }

        if (existingHistory == null)
        {
            dbContext.Add(history.ToDbHistory());
            return;
        }
        
        dbContext.Update(history.ToDbHistory());
    }
    private void UpdateRelatedEntitiesWithHistory<T1, T2>(T1[] entities, T1[]? existingEntities, Func<T1, T2> onGetDbEntity) 
        where T1 : BaseEntityDto where T2 : class
    {
        foreach (var entity in entities)
        {
            var existingEntity = existingEntities?.FirstOrDefault(x => x.EntityId == entity.EntityId);

            UpdateHistory(entity.History, existingEntity?.History);
            if (existingEntity == null)
            {
                dbContext.Add(onGetDbEntity(entity));    
            }
            else
            {
                dbContext.Update(onGetDbEntity(entity));
            }
        }
        foreach (var existingEntity in existingEntities ?? [])
        {
            UpdateHistory(null, existingEntity.History);
            if (entities.All(x => x.EntityId != existingEntity.EntityId))
            {
                dbContext.Remove(onGetDbEntity(existingEntity));
            }
        }
    }
    

    public async Task<CreateorUpdateProjectResult> CreateOrUpdateProject(ProjectDto project, EntityUpdatingContext changeContext, CancellationToken ct)
    {
        var existingProject = project.EntityNeedsToBeCreated
            ? null
            : (await GetProjects(query => query.Where(x => x.EntityId == project.EntityId), query => query, ct))
            .FirstOrDefault();

        return (await dbContext.ExecuteInTransactionAndLogErrorIfFails(async (transaction,ctInner) =>
        {
            SaveRequirementSpecification(project.RequirementSpecifications, existingProject?.RequirementSpecifications ?? []);
            SaveTimeSpecification(project.TimeSpecifications, existingProject?.TimeSpecifications ?? []);
            UpdateRelatedEntitiesWithHistory(project.LocationSpecifications, existingProject?.LocationSpecifications, x => x.ToDbLocationSpecification());
            UpdateRelatedEntitiesWithHistory(project.ContactSpecifications, existingProject?.ContactSpecifications, x => x.ToDbContactSpecification());
            SaveDescriptionSpecification(project.DescriptionSpecifications, existingProject?.DescriptionSpecifications ?? []);
            UpdateRelatedEntitiesWithHistory(project.GraphicsSpecifications, existingProject?.GraphicsSpecifications, x => x.ToDbGraphicsSpecification());
            AddOrUpdateWithHistory(project, null, x => x.ToDbProject());
            await dbContext.SaveChangesAsync(ctInner);
            await transaction.CommitAsync(ctInner);
            var resultProject =
                (await GetProjects(query => query.Where(x => x.EntityId == project.EntityId), query => query, ctInner))
                .FirstOrDefault();
            
            // todo: save history from changeContext
            
            return new CreateorUpdateProjectResult { Success = true, Project = resultProject };
        }, logger, ct)).ToCreateProjectResult();
    }

    private void SaveRequirementSpecification(RequirementSpecificationDto[] requirementSpecifications, RequirementSpecificationDto[] existingRequirementSpecifications)
    {
        foreach (var entity in requirementSpecifications)
        {
            var existingEntity = existingRequirementSpecifications?.FirstOrDefault(x => x.EntityId == entity.EntityId);

            SaveTimeSpecification(entity.TimeSpecifications, existingEntity?.TimeSpecifications ?? []);
            
            AddOrUpdateWithHistory(entity.QuantitySpecification, existingEntity?.QuantitySpecification, x => x.ToDbQuantitySpecification());
            if (entity is RequirementSpecificationDtoMaterial requirementSpecificationDtoMaterial)
            {
                UpdateRelatedEntitiesWithHistory(requirementSpecificationDtoMaterial.MaterialSpecifications, (existingEntity as RequirementSpecificationDtoMaterial)?.MaterialSpecifications, x => x.ToDbMaterialSpecification());
                UpdateRelatedEntitiesWithHistory(requirementSpecificationDtoMaterial.LocationSpecifications, (existingEntity as RequirementSpecificationDtoMaterial)?.LocationSpecifications, x => x.ToDbLocationSpecification());
            }

            if (entity is RequirementSpecificationDtoPerson requirementSpecificationDtoPerson)
            {
                UpdateRelatedEntitiesWithHistory(requirementSpecificationDtoPerson.SkillSpecifications, (existingEntity as RequirementSpecificationDtoPerson)?.SkillSpecifications, x => x.ToDbSkillSpecification());
                UpdateRelatedEntityWithHistory(requirementSpecificationDtoPerson.WorkAmountSpecification, (existingEntity as RequirementSpecificationDtoPerson)?.WorkAmountSpecification, x => x.ToDbWorkAmountSpecification());
                UpdateRelatedEntitiesWithHistory(requirementSpecificationDtoPerson.LocationSpecifications, (existingEntity as RequirementSpecificationDtoPerson)?.LocationSpecifications, x => x.ToDbLocationSpecification());
            }
            AddOrUpdateWithHistory(entity, existingEntity, x => x.ToDbRequirementSpecification());
        }
        foreach (var existingEntity in existingRequirementSpecifications ?? [])
        {
            if (requirementSpecifications.All(x => x.EntityId != existingEntity.EntityId))
            {
                SaveTimeSpecification([], existingEntity.TimeSpecifications);
                RemoveWithHistory(existingEntity.QuantitySpecification, x => x.ToDbQuantitySpecification());
                
                
                if (existingEntity is RequirementSpecificationDtoMaterial requirementSpecificationDtoMaterial)
                {
                    UpdateRelatedEntitiesWithHistory([], requirementSpecificationDtoMaterial.MaterialSpecifications, x => x.ToDbMaterialSpecification());
                    UpdateRelatedEntitiesWithHistory([], requirementSpecificationDtoMaterial.LocationSpecifications, x => x.ToDbLocationSpecification());
                }
                
                if (existingEntity is RequirementSpecificationDtoPerson requirementSpecificationDtoPerson)
                {
                    UpdateRelatedEntitiesWithHistory([], requirementSpecificationDtoPerson.SkillSpecifications, x => x.ToDbSkillSpecification());
                    UpdateRelatedEntityWithHistory(null, requirementSpecificationDtoPerson.WorkAmountSpecification, x => x.ToDbWorkAmountSpecification());
                    UpdateRelatedEntitiesWithHistory([], requirementSpecificationDtoPerson.LocationSpecifications, x => x.ToDbLocationSpecification());
                }
                RemoveWithHistory(existingEntity, x => x.ToDbRequirementSpecification());
            }
        }
    }

    private void RemoveWithHistory<T1, T2>(T1 entity, Func<T1, T2> toDbEntity)
        where T1 : BaseEntityDto where T2 : class
    {
        UpdateHistory(null, entity.History);
        dbContext.Remove(toDbEntity(entity));
    }

    private void SaveTimeSpecification(TimeSpecificationDto[] timeSpecifications, TimeSpecificationDto[] existingTimeSpecifications)
    {
        foreach (var entity in timeSpecifications)
        {
            var existingEntity = existingTimeSpecifications?.FirstOrDefault(x => x.EntityId == entity.EntityId);

            if (entity is TimeSpecificationDtoPeriod timeSpecificationDtoPeriod)
            {
                AddOrUpdateWithHistory(timeSpecificationDtoPeriod.Start, (existingEntity as TimeSpecificationDtoPeriod)?.Start, x => x.ToDbTimeSpecificationMoment());
                AddOrUpdateWithHistory(timeSpecificationDtoPeriod.End, (existingEntity as TimeSpecificationDtoPeriod)?.End, x => x.ToDbTimeSpecificationMoment());
            }
            AddOrUpdateWithHistory(entity, existingEntity, x => x.ToDbTimeSpecification());
        }
        foreach (var existingEntity in existingTimeSpecifications ?? [])
        {
            if (timeSpecifications.All(x => x.EntityId != existingEntity.EntityId))
            {
                if (existingEntity is TimeSpecificationDtoPeriod timeSpecificationDtoPeriod)
                {
                    RemoveWithHistory(timeSpecificationDtoPeriod.Start, x => x.ToDbTimeSpecificationMoment());
                    RemoveWithHistory(timeSpecificationDtoPeriod.End, x => x.ToDbTimeSpecificationMoment());
                }

                RemoveWithHistory(existingEntity, x => x.ToDbTimeSpecification());
            }
        }
    }
    
    private void SaveDescriptionSpecification(DescriptionSpecificationDto[] descriptionSpecifications, DescriptionSpecificationDto[] existingDescriptionSpecifications)
    {
        foreach (var entity in descriptionSpecifications)
        {
            var existingEntity = existingDescriptionSpecifications?.FirstOrDefault(x => x.EntityId == entity.EntityId);

            UpdateHistory(entity.Type.History, existingEntity?.Type.History);
            AddOrUpdateWithHistory(entity, existingEntity, x => x.ToDbDescriptionSpecification());
        }
        foreach (var existingEntity in existingDescriptionSpecifications ?? [])
        {
            if (descriptionSpecifications.All(x => x.EntityId != existingEntity.EntityId))
            {
                UpdateHistory(null, existingEntity.Type.History);
                RemoveWithHistory(existingEntity, x => x.ToDbDescriptionSpecification());
            }
        }
    }

    private void AddOrUpdateWithHistory<T1, T2>(T1? entity, T1? existingEntity, Func<T1, T2> toDbEntity)
    where T1 : BaseEntityDto where T2 : class
    {
        UpdateHistory(entity?.History, existingEntity?.History);
        if (entity != null)
        {
            dbContext.AddOrUpdate(toDbEntity(entity), existingEntity != null);
        }
    }
}
