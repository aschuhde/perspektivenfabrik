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
    
    private void UpdateRelatedEntity<T1, T2>(T1? entity, T1? existingEntity, Func<T1, T2> onGetDbEntity) 
        where T1 : BaseEntityWithIdDto where T2 : class
    {
        if (existingEntity == null && entity == null)
        {
            return;
        }
        
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
    private void UpdateRelatedEntities<T1, T2>(T1[] entities, T1[]? existingEntities,
        Func<T1, T2> onGetDbEntity)
        where T1 : BaseEntityWithIdDto where T2 : class
    {
        foreach (var entity in entities)
        {
            var existingEntity = existingEntities?.FirstOrDefault(x => x.EntityId == entity.EntityId);
            
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
            UpdateRelatedEntities(project.LocationSpecifications, existingProject?.LocationSpecifications, x => x.ToDbLocationSpecification());
            UpdateRelatedEntities(project.ContactSpecifications, existingProject?.ContactSpecifications, x => x.ToDbContactSpecification());
            SaveDescriptionSpecification(project.DescriptionSpecifications, existingProject?.DescriptionSpecifications ?? []);
            UpdateRelatedEntities(project.GraphicsSpecifications, existingProject?.GraphicsSpecifications, x => x.ToDbGraphicsSpecification());
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
            
            AddOrUpdate(entity.QuantitySpecification, existingEntity?.QuantitySpecification, x => x.ToDbQuantitySpecification());
            if (entity is RequirementSpecificationDtoMaterial requirementSpecificationDtoMaterial)
            {
                UpdateRelatedEntities(requirementSpecificationDtoMaterial.MaterialSpecifications, (existingEntity as RequirementSpecificationDtoMaterial)?.MaterialSpecifications, x => x.ToDbMaterialSpecification());
                UpdateRelatedEntities(requirementSpecificationDtoMaterial.LocationSpecifications, (existingEntity as RequirementSpecificationDtoMaterial)?.LocationSpecifications, x => x.ToDbLocationSpecification());
            }

            if (entity is RequirementSpecificationDtoPerson requirementSpecificationDtoPerson)
            {
                UpdateRelatedEntities(requirementSpecificationDtoPerson.SkillSpecifications, (existingEntity as RequirementSpecificationDtoPerson)?.SkillSpecifications, x => x.ToDbSkillSpecification());
                UpdateRelatedEntity(requirementSpecificationDtoPerson.WorkAmountSpecification, (existingEntity as RequirementSpecificationDtoPerson)?.WorkAmountSpecification, x => x.ToDbWorkAmountSpecification());
                UpdateRelatedEntities(requirementSpecificationDtoPerson.LocationSpecifications, (existingEntity as RequirementSpecificationDtoPerson)?.LocationSpecifications, x => x.ToDbLocationSpecification());
            }
            AddOrUpdate(entity, existingEntity, x => x.ToDbRequirementSpecification());
        }
        foreach (var existingEntity in existingRequirementSpecifications ?? [])
        {
            if (requirementSpecifications.All(x => x.EntityId != existingEntity.EntityId))
            {
                SaveTimeSpecification([], existingEntity.TimeSpecifications);
                Remove(existingEntity.QuantitySpecification, x => x.ToDbQuantitySpecification());
                
                
                if (existingEntity is RequirementSpecificationDtoMaterial requirementSpecificationDtoMaterial)
                {
                    UpdateRelatedEntities([], requirementSpecificationDtoMaterial.MaterialSpecifications, x => x.ToDbMaterialSpecification());
                    UpdateRelatedEntities([], requirementSpecificationDtoMaterial.LocationSpecifications, x => x.ToDbLocationSpecification());
                }
                
                if (existingEntity is RequirementSpecificationDtoPerson requirementSpecificationDtoPerson)
                {
                    UpdateRelatedEntities([], requirementSpecificationDtoPerson.SkillSpecifications, x => x.ToDbSkillSpecification());
                    UpdateRelatedEntity(null, requirementSpecificationDtoPerson.WorkAmountSpecification, x => x.ToDbWorkAmountSpecification());
                    UpdateRelatedEntities([], requirementSpecificationDtoPerson.LocationSpecifications, x => x.ToDbLocationSpecification());
                }
                Remove(existingEntity, x => x.ToDbRequirementSpecification());
            }
        }
    }

    private void Remove<T1, T2>(T1 entity, Func<T1, T2> toDbEntity)
        where T1 : BaseEntityWithIdDto where T2 : class
    {
        dbContext.Remove(toDbEntity(entity));
    }

    private void SaveTimeSpecification(TimeSpecificationDto[] timeSpecifications, TimeSpecificationDto[] existingTimeSpecifications)
    {
        foreach (var entity in timeSpecifications)
        {
            var existingEntity = existingTimeSpecifications?.FirstOrDefault(x => x.EntityId == entity.EntityId);

            if (entity is TimeSpecificationDtoPeriod timeSpecificationDtoPeriod)
            {
                AddOrUpdate(timeSpecificationDtoPeriod.Start, (existingEntity as TimeSpecificationDtoPeriod)?.Start, x => x.ToDbTimeSpecificationMoment());
                AddOrUpdate(timeSpecificationDtoPeriod.End, (existingEntity as TimeSpecificationDtoPeriod)?.End, x => x.ToDbTimeSpecificationMoment());
            }
            AddOrUpdate(entity, existingEntity, x => x.ToDbTimeSpecification());
        }
        foreach (var existingEntity in existingTimeSpecifications ?? [])
        {
            if (timeSpecifications.All(x => x.EntityId != existingEntity.EntityId))
            {
                if (existingEntity is TimeSpecificationDtoPeriod timeSpecificationDtoPeriod)
                {
                    Remove(timeSpecificationDtoPeriod.Start, x => x.ToDbTimeSpecificationMoment());
                    Remove(timeSpecificationDtoPeriod.End, x => x.ToDbTimeSpecificationMoment());
                }

                Remove(existingEntity, x => x.ToDbTimeSpecification());
            }
        }
    }
    
    private void SaveDescriptionSpecification(DescriptionSpecificationDto[] descriptionSpecifications, DescriptionSpecificationDto[] existingDescriptionSpecifications)
    {
        foreach (var entity in descriptionSpecifications)
        {
            var existingEntity = existingDescriptionSpecifications?.FirstOrDefault(x => x.EntityId == entity.EntityId);
            
            AddOrUpdate(entity, existingEntity, x => x.ToDbDescriptionSpecification());
        }
        foreach (var existingEntity in existingDescriptionSpecifications ?? [])
        {
            if (descriptionSpecifications.All(x => x.EntityId != existingEntity.EntityId))
            {
                Remove(existingEntity, x => x.ToDbDescriptionSpecification());
            }
        }
    }

    private void AddOrUpdate<T1, T2>(T1? entity, T1? existingEntity, Func<T1, T2> toDbEntity)
    where T1 : BaseEntityWithIdDto where T2 : class
    {
        if (entity != null)
        {
            dbContext.AddOrUpdate(toDbEntity(entity), existingEntity != null);
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
