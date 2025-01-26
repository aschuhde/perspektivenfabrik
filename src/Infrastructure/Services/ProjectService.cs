using Application.Filter;
using Application.Models.ProjectService;
using Application.Selectors;
using Application.Services;
using Application.Updaters;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Data;
using Infrastructure.Data.DbEntities;
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
        return (await selectFunction(filterFunction(dbContext.Projects)).AsNoTracking().ToArrayAsync(ct)).Select(x => x.ToProject()).ToArray();
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
        return (await dbContext.Projects.Where(x => x.EntityId == entityId).AsNoTracking().FirstOrDefaultAsync(ct))?.ToProject();
    }
    
    private void UpdateRelatedEntities<T1, T2>(T1[] entities, T1[]? existingEntities, Func<T1, T2> onGetDbEntity) 
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
        var exists = existingProject != null;
        
        return (await dbContext.ExecuteInTransactionAndLogErrorIfFails(async (_,ctInner) =>
        {
            var dbEntity = project.ToDbProject();
            SaveRequirementSpecification(project.RequirementSpecifications, existingProject?.RequirementSpecifications ?? []);
            SaveTimeSpecification(project.TimeSpecifications, existingProject?.TimeSpecifications ?? []);
            UpdateRelatedEntities(project.LocationSpecifications, existingProject?.LocationSpecifications, x => x.ToDbLocationSpecification());
            UpdateRelatedEntities(project.ContactSpecifications, existingProject?.ContactSpecifications, x => x.ToDbContactSpecification());
            UpdateRelatedEntities(project.DescriptionSpecifications, existingProject?.DescriptionSpecifications, x => x.ToDbDescriptionSpecification());
            UpdateRelatedEntities(project.GraphicsSpecifications, existingProject?.GraphicsSpecifications, x => x.ToDbGraphicsSpecification());
            AddOrUpdate(dbEntity, exists);
            var resultProject =
                (await GetProjects(query => query.Where(x => x.EntityId == dbEntity.EntityId), query => query, ctInner))
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
            
            AddOrUpdate(entity.QuantitySpecification, existingEntity?.QuantitySpecification != null);
            if (entity is RequirementSpecificationDtoMaterial requirementSpecificationDtoMaterial)
            {
                UpdateRelatedEntities(requirementSpecificationDtoMaterial.MaterialSpecifications, (existingEntity as RequirementSpecificationDtoMaterial)?.MaterialSpecifications, x => x.ToDbMaterialSpecification());
                UpdateRelatedEntities(requirementSpecificationDtoMaterial.LocationSpecifications, (existingEntity as RequirementSpecificationDtoMaterial)?.LocationSpecifications, x => x.ToDbLocationSpecification());
            }

            if (entity is RequirementSpecificationDtoMoney requirementSpecificationDtoMoney)
            {
                UpdateRelatedEntities(requirementSpecificationDtoMoney.MaterialSpecifications, (existingEntity as RequirementSpecificationDtoMoney)?.MaterialSpecifications, x => x.ToDbMaterialSpecification());
            }

            if (entity is RequirementSpecificationDtoPerson requirementSpecificationDtoPerson)
            {
                UpdateRelatedEntities(requirementSpecificationDtoPerson.SkillSpecifications, (existingEntity as RequirementSpecificationDtoPerson)?.SkillSpecifications, x => x.ToDbSkillSpecification());
                UpdateRelatedEntities(requirementSpecificationDtoPerson.WorkAmountSpecifications, (existingEntity as RequirementSpecificationDtoPerson)?.WorkAmountSpecifications, x => x.ToDbWorkAmountSpecification());
                UpdateRelatedEntities(requirementSpecificationDtoPerson.LocationSpecifications, (existingEntity as RequirementSpecificationDtoPerson)?.LocationSpecifications, x => x.ToDbLocationSpecification());
            }
            AddOrUpdate(entity, existingEntity != null);
        }
        foreach (var existingEntity in existingRequirementSpecifications ?? [])
        {
            if (requirementSpecifications.All(x => x.EntityId != existingEntity.EntityId))
            {
                SaveTimeSpecification([], existingEntity.TimeSpecifications);
                dbContext.Remove(existingEntity.QuantitySpecification);
                
                
                if (existingEntity is RequirementSpecificationDtoMaterial requirementSpecificationDtoMaterial)
                {
                    UpdateRelatedEntities([], requirementSpecificationDtoMaterial.MaterialSpecifications, x => x.ToDbMaterialSpecification());
                    UpdateRelatedEntities([], requirementSpecificationDtoMaterial.LocationSpecifications, x => x.ToDbLocationSpecification());
                }

                if (existingEntity is RequirementSpecificationDtoMoney requirementSpecificationDtoMoney)
                {
                    UpdateRelatedEntities([], requirementSpecificationDtoMoney.MaterialSpecifications, x => x.ToDbMaterialSpecification());
                }

                if (existingEntity is RequirementSpecificationDtoPerson requirementSpecificationDtoPerson)
                {
                    UpdateRelatedEntities([], requirementSpecificationDtoPerson.SkillSpecifications, x => x.ToDbSkillSpecification());
                    UpdateRelatedEntities([], requirementSpecificationDtoPerson.WorkAmountSpecifications, x => x.ToDbWorkAmountSpecification());
                    UpdateRelatedEntities([], requirementSpecificationDtoPerson.LocationSpecifications, x => x.ToDbLocationSpecification());
                }
                dbContext.Remove(existingEntity);
            }
        }
    }
    private void SaveTimeSpecification(TimeSpecificationDto[] timeSpecifications, TimeSpecificationDto[] existingTimeSpecifications)
    {
        foreach (var entity in timeSpecifications)
        {
            var existingEntity = existingTimeSpecifications?.FirstOrDefault(x => x.EntityId == entity.EntityId);

            if (entity is TimeSpecificationDtoPeriod timeSpecificationDtoPeriod)
            {
                AddOrUpdate(timeSpecificationDtoPeriod.Start.ToDbTimeSpecificationMoment(), existingEntity != null);
                AddOrUpdate(timeSpecificationDtoPeriod.End.ToDbTimeSpecificationMoment(), existingEntity != null);
            }
            AddOrUpdate(entity.ToDbTimeSpecification(), existingEntity != null);
        }
        foreach (var existingEntity in existingTimeSpecifications ?? [])
        {
            if (timeSpecifications.All(x => x.EntityId != existingEntity.EntityId))
            {
                if (existingEntity is TimeSpecificationDtoPeriod timeSpecificationDtoPeriod)
                {
                    dbContext.Remove(timeSpecificationDtoPeriod.Start.ToDbTimeSpecificationMoment());
                    dbContext.Remove(timeSpecificationDtoPeriod.End.ToDbTimeSpecificationMoment());
                }

                dbContext.Remove(existingEntity.ToDbTimeSpecification());
            }
        }
    }

    private void AddOrUpdate<TEntity>(TEntity entity, bool entityExists)
    {
        dbContext.AddOrUpdate(entity, entityExists);
    }
}
