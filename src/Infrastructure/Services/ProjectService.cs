using System.Diagnostics;
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
  private async Task<ProjectDto[]> GetProjects(Func<IQueryable<DbProject>, IQueryable<DbProject>> filterFunction,
    Func<IQueryable<DbProject>, IQueryable<DbProject>> selectFunction, CancellationToken ct)
  {
    return (await GetDbProjects(filterFunction, selectFunction, false, ct)).Select(x => x.ToProject()).ToArray();
  }
    private async Task<DbProject[]> GetDbProjects(Func<IQueryable<DbProject>, IQueryable<DbProject>> filterFunction, Func<IQueryable<DbProject>, IQueryable<DbProject>> selectFunction, bool withTracking, CancellationToken ct)
    {
        var query = selectFunction(filterFunction(dbContext.Projects.AsSplitQuery().IncludeFull()));
        if (!withTracking)
        {
          query = query.AsNoTracking();
        }

        // var projects = await selectFunction(filterFunction(dbContext.Projects)).AsNoTracking()
        //   .ToArrayAsync(ct);
        //
        // var projectIds = projects.Select(x => x.EntityId).ToArray();
        // var query2 = dbContext.RequirementSpecificationProjectConnections.Include(x => x.RequirementSpecification)
        //   .Where(x => projectIds.Contains(x.ProjectId)).AsNoTracking();
        // var requirements = (await query2.ToArrayAsync(ct)).Select(x => x.RequirementSpecification!).ToArray();
        //
        // var requirementIds = requirements.Select(x => x.EntityId).ToArray();
        // var requirementTimeSpecifications = await dbContext.TimeSpecificationRequirementConnections.Include(x => x.TimeSpecification)
        //   .Where(x => requirementIds.Contains(x.EntityId)).AsNoTracking().ToArrayAsync(ct);
        // var requirementLocationSpecifications = await dbContext.LocationSpecificationRequirementConnections.Include(x => x.LocationSpecification)
        //   .Where(x => requirementIds.Contains(x.EntityId)).AsNoTracking().ToArrayAsync(ct);
        // var requirementSkillSpecifications =  await dbContext.SkillSpecificationRequirementConnections.Include(x => x.SkillSpecification)
        //   .Where(x => requirementIds.Contains(x.EntityId)).AsNoTracking().ToArrayAsync(ct);
        // var requirementMaterialSpecifications =  await dbContext.MaterialSpecificationRequirementConnections.Include(x => x.MaterialSpecification)
        //   .Where(x => requirementIds.Contains(x.EntityId)).AsNoTracking().ToArrayAsync(ct);
        // var requirementWorkAmountSpecifications =  await dbContext.WorkAmountSpecificationRequirementConnections.Include(x => x.WorkAmountSpecification)
        //   .Where(x => requirementIds.Contains(x.EntityId)).AsNoTracking().ToArrayAsync(ct);
        // var requirementQuantitySpecifications =  await dbContext.QuantitySpecificationRequirementConnections.Include(x => x.QuantitySpecification)
        //   .Where(x => requirementIds.Contains(x.EntityId)).AsNoTracking().ToArrayAsync(ct);
        //
        // var projectTimeSpecifications = await dbContext.TimeSpecificationProjectConnections.Include(x => x.TimeSpecification)
        //   .Where(x => requirementIds.Contains(x.EntityId)).AsNoTracking().ToArrayAsync(ct);
        // var projectLocationSpecifications = await dbContext.LocationSpecificationProjectConnections.Include(x => x.LocationSpecification)
        //   .Where(x => requirementIds.Contains(x.EntityId)).AsNoTracking().ToArrayAsync(ct);
        // var projectTagSpecifications = await dbContext.ProjectTagConnections.Include(x => x.ProjectTag)
        //   .Where(x => requirementIds.Contains(x.EntityId)).AsNoTracking().ToArrayAsync(ct);
        // var projectContactSpecifications = await dbContext.ContactSpecificationsProjectConnections.Include(x => x.ContactSpecification)
        //   .Where(x => requirementIds.Contains(x.EntityId)).AsNoTracking().ToArrayAsync(ct);
        // var projectDescriptionSpecifications = await dbContext.DescriptionSpecificationProjectConnections.Include(x => x.DescriptionSpecification)
        //   .Where(x => requirementIds.Contains(x.EntityId)).AsNoTracking().ToArrayAsync(ct);
        // var projectGraphicsSpecifications = await dbContext.GraphicsSpecificationProjectConnections.Include(x => x.GraphicsSpecification)
        //   .Where(x => requirementIds.Contains(x.EntityId)).AsNoTracking().ToArrayAsync(ct);
        //
        //
        #if DEBUG
        var queryString = query.ToQueryString();
        // var queryString2 = query2.ToQueryString();
        #endif
        var start = Stopwatch.GetTimestamp();
        var result = (await query.ToArrayAsync(ct));
        var elapsed = (Stopwatch.GetTimestamp() - start) * 1000 / Stopwatch.Frequency;

        return result;

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

    private void RemoveRelatedEntity<TConnection, TDbEntity>(TConnection? existingEntityConnection,
      Func<TConnection, TDbEntity> onGetExistingEntity, Func<TConnection, TConnection> onGetConnectionWithoutRelatedEntites, Func<TDbEntity, TDbEntity> onGetEntityWithoutRelatedEntites) where TDbEntity : DbEntityWithId where TConnection : class
    {
        UpdateRelatedEntity<BaseEntityDto, TConnection, TDbEntity>(null, existingEntityConnection, null, onGetExistingEntity, onGetConnectionWithoutRelatedEntites, onGetEntityWithoutRelatedEntites);
    }
    private void UpdateRelatedEntity<TDto, TConnection, TDbEntity>(TDto? entity, TConnection? existingEntityConnection,
      Func<TDto, TDbEntity>? onGetDbEntity, Func<TConnection, TDbEntity> onGetExistingEntity, Func<TConnection, TConnection> onGetConnectionWithoutRelatedEntites, Func<TDbEntity, TDbEntity> onGetEntityWithoutRelatedEntites)
      where TDto : BaseEntityWithIdDto where TDbEntity : DbEntityWithId where TConnection : class
    {
        if (existingEntityConnection == null && entity == null)
        {
            return;
        }
        
        if (existingEntityConnection == null)
        {
          if (onGetDbEntity != null)
          {
            dbContext.Add(onGetDbEntity(entity!));
          }
        }
        else
        {
            if (entity == null || entity.EntityId != onGetExistingEntity(existingEntityConnection).EntityId)
            {
                dbContext.Remove(existingEntityConnection);
                dbContext.Remove(onGetExistingEntity(existingEntityConnection));
            }
            else
            {
              if (onGetDbEntity != null)
              {
                AddOrUpdate(entity, onGetExistingEntity(existingEntityConnection), x => onGetEntityWithoutRelatedEntites(onGetDbEntity(x)));
              }
            }
        }
    }

    private void UpdateHistoryItems(ModificationHistoryDto? history, DbModificationHistory? existingHistory)
    {
        var historyItems = history?.HistoryItems?.ToArray() ?? [];
        var existingHistoryItems = existingHistory?.HistoryItems?.ToArray() ?? [];
        foreach (var historyItem in historyItems)
        {
            var existingHistoryItem = existingHistoryItems.FirstOrDefault(x => x.EntityId == historyItem.EntityId);

            if (existingHistoryItem == null)
            {
                dbContext.Add(historyItem.ToDbHistoryItem(history!));    
            }
            else
            {
                existingHistoryItem.UpdateToTarget(historyItem.ToDbHistoryItem(history!));
            }
        }
        foreach (var existingHistoryItem in existingHistoryItems)
        {
            if (historyItems.All(x => x.EntityId != existingHistoryItem.EntityId))
            {
                dbContext.Remove(existingHistoryItem);
            }
        }
    }
    private void UpdateHistory(ModificationHistoryDto? history, DbModificationHistoryConnection? existingHistoryConnection)
    {
        if (history == null && existingHistoryConnection == null)
        {
            return;
        }
        UpdateHistoryItems(history, existingHistoryConnection?.History);
        if (existingHistoryConnection != null && (history == null || history.EntityId != existingHistoryConnection.History?.EntityId))
        {
            Remove(existingHistoryConnection);
            Remove(existingHistoryConnection.History);
            return;
        }

        if (history == null)
        {
            return;
        }

        if (existingHistoryConnection == null || history.EntityId != existingHistoryConnection.History?.EntityId)
        {
            dbContext.Add(history.ToDbHistoryWithoutHistoryItems());
            return;
        }

        existingHistoryConnection.History.UpdateToTarget(history.ToDbHistory());
    }
    private void ConcurrencyFix(){
      foreach (var entry in dbContext.ChangeTracker.Entries().Where(e => 
                 e.State == EntityState.Unchanged
                 && e.References.Any(r =>
                   r.TargetEntry != null
                   && r.TargetEntry.State == EntityState.Modified
                   && r.TargetEntry.Metadata.IsOwned()
                   && e.Metadata.GetTableName() == r.TargetEntry.Metadata.GetTableName())))
        entry.State = EntityState.Modified;
    }
    public async Task<CreateorUpdateProjectResult> CreateOrUpdateProject(ProjectDto project, EntityUpdatingContext changeContext, CancellationToken ct)
    {
        var existingProject = changeContext.IsCreating
            ? null
            : (await GetDbProjects(query => query.Where(x => x.EntityId == project.EntityId), query => query, true, ct))
            .FirstOrDefault();

        return (await dbContext.ExecuteInTransactionAndLogErrorIfFails(async (transaction,ctInner) =>
        {
            SaveRequirementSpecification(project.RequirementSpecifications, existingProject?.RequirementSpecifications?.ToArray() ?? []);
            SaveProjectTimeSpecifications(project.TimeSpecifications, existingProject?.TimeSpecifications?.ToArray() ?? []);
            UpdateRelatedEntities(project.LocationSpecifications, existingProject?.LocationSpecifications?.ToArray(), x => x.ToDbLocationSpecification(), x => x.LocationSpecification!, x => x, x => x);
            UpdateRelatedEntities(project.ContactSpecifications, existingProject?.ContactSpecifications?.ToArray(), x => x.ToDbContactSpecification(), x => x.ContactSpecification!, x => x, x => x);
            SaveDescriptionSpecification(project.DescriptionSpecifications, existingProject?.DescriptionSpecifications?.ToArray() ?? []);
            UpdateRelatedEntities(project.GraphicsSpecifications, existingProject?.GraphicsSpecifications?.ToArray(), x => x.ToDbGraphicsSpecification(), x => x.GraphicsSpecification!, x => x, x => x);
            AddOrUpdateProject(project, existingProject);
            await dbContext.SaveChangesAsync(ctInner);
            await transaction.CommitAsync(ctInner);
            var resultProject =
                (await GetProjects(query => query.Where(x => x.EntityId == project.EntityId), query => query, ctInner))
                .FirstOrDefault();
            
            // todo: save history from changeContext
            
            return new CreateorUpdateProjectResult { Success = true, Project = resultProject };
        }, logger, ct)).ToCreateProjectResult();
    }

    private void SaveRequirementSpecification(RequirementSpecificationDto[] requirementSpecifications, DbRequirementSpecificationProjectConnection[] existingRequirementSpecifications)
    {
        foreach (var entity in requirementSpecifications)
        {
            var existingEntity = existingRequirementSpecifications?.FirstOrDefault(x => x.RequirementSpecificationId == entity.EntityId);

            SaveRequirementTimeSpecifications(entity.TimeSpecifications, existingEntity?.RequirementSpecification?.TimeSpecifications?.ToArray() ?? []);
            
            AddOrUpdate(entity.QuantitySpecification, existingEntity?.RequirementSpecification?.QuantitySpecification?.QuantitySpecification, x => x.ToDbQuantitySpecification());
            if (entity is RequirementSpecificationDtoMaterial requirementSpecificationDtoMaterial)
            {
                UpdateRelatedEntities(requirementSpecificationDtoMaterial.MaterialSpecifications, (existingEntity?.RequirementSpecification as DbRequirementSpecificationMaterial)?.MaterialSpecifications?.ToArray() ?? [], x => x.ToDbMaterialSpecification(), x => x.MaterialSpecification!, x => x, x => x);
                UpdateRelatedEntities(requirementSpecificationDtoMaterial.LocationSpecifications, (existingEntity?.RequirementSpecification as DbRequirementSpecificationMaterial)?.LocationSpecifications?.ToArray() ?? [], x => x.ToDbLocationSpecification(), x => x.LocationSpecification!, x => x, x => x);
            }

            if (entity is RequirementSpecificationDtoPerson requirementSpecificationDtoPerson)
            {
                UpdateRelatedEntities(requirementSpecificationDtoPerson.SkillSpecifications, (existingEntity?.RequirementSpecification as DbRequirementSpecificationPerson)?.SkillSpecifications?.ToArray() ?? [], x => x.ToDbSkillSpecification(), x => x.SkillSpecification!, x => x, x => x);
                UpdateRelatedEntity(requirementSpecificationDtoPerson.WorkAmountSpecification, (existingEntity?.RequirementSpecification as DbRequirementSpecificationPerson)?.WorkAmountSpecification, x => x.ToDbWorkAmountSpecification(), x => x.WorkAmountSpecification!, x => x, x => x);
                UpdateRelatedEntities(requirementSpecificationDtoPerson.LocationSpecifications, (existingEntity?.RequirementSpecification as DbRequirementSpecificationPerson)?.LocationSpecifications?.ToArray() ?? [], x => x.ToDbLocationSpecification(), x => x.LocationSpecification!, x => x, x => x);
            }
            AddOrUpdate(entity, existingEntity?.RequirementSpecification, x => x.ToDbRequirementSpecification());
        }
        foreach (var existingEntity in existingRequirementSpecifications ?? [])
        {
            if (requirementSpecifications.All(x => x.EntityId != existingEntity.EntityId))
            {
                SaveRequirementTimeSpecifications([], existingEntity.RequirementSpecification?.TimeSpecifications?.ToArray() ?? []);
                Remove(existingEntity.RequirementSpecification?.QuantitySpecification);
                Remove(existingEntity.RequirementSpecification?.QuantitySpecification?.QuantitySpecification);
                
                
                if (existingEntity.RequirementSpecification is DbRequirementSpecificationMaterial dbRequirementSpecificationMaterial)
                {
                    RemoveRelatedEntities(dbRequirementSpecificationMaterial.MaterialSpecifications?.ToArray() ?? [], x => x.MaterialSpecification!, x => x, x => x);
                    RemoveRelatedEntities(dbRequirementSpecificationMaterial.LocationSpecifications?.ToArray() ?? [], x => x.LocationSpecification!, x => x, x => x);
                }
                
                if (existingEntity.RequirementSpecification is DbRequirementSpecificationPerson requirementSpecificationDtoPerson)
                {
                    RemoveRelatedEntities(requirementSpecificationDtoPerson.SkillSpecifications?.ToArray() ?? [], x => x.SkillSpecification!, x => x, x => x);
                    RemoveRelatedEntity(requirementSpecificationDtoPerson.WorkAmountSpecification, x => x.WorkAmountSpecification!, x => x, x => x);
                    RemoveRelatedEntities(requirementSpecificationDtoPerson.LocationSpecifications?.ToArray() ?? [], x => x.LocationSpecification!, x => x, x => x);
                }
                Remove(existingEntity);
                Remove(existingEntity.RequirementSpecification);
            }
        }
    }

    private void Remove<T1>(T1? entity)
    {
      if (entity == null)
      {
        return;
      }
      dbContext.Remove(entity);
    }

    private void SaveProjectTimeSpecifications(TimeSpecificationDto[] timeSpecifications,
      DbTimeSpecificationProjectConnection[] existingTimeSpecifications)
    {
      SaveTimeSpecifications(timeSpecifications, existingTimeSpecifications, x => x.TimeSpecification!);
    }

    private void SaveRequirementTimeSpecifications(TimeSpecificationDto[] timeSpecifications,
      DbTimeSpecificationRequirementConnection[] existingTimeSpecifications)
    {
      SaveTimeSpecifications(timeSpecifications, existingTimeSpecifications, x => x.TimeSpecification!);
    }
    private void SaveTimeSpecifications<TConnection>(TimeSpecificationDto[] timeSpecifications, TConnection[] existingTimeSpecificationConnections, Func<TConnection, DbTimeSpecification> onGetExistingEntity)
    where TConnection : class
    {
      foreach (var entity in timeSpecifications)
      {
        var existingEntityConnection = existingTimeSpecificationConnections?.FirstOrDefault(x => onGetExistingEntity(x).EntityId == entity.EntityId);
        var existingEntity = existingEntityConnection != null ? onGetExistingEntity(existingEntityConnection) : null;
        if (entity is TimeSpecificationDtoPeriod timeSpecificationDtoPeriod)
        {
          AddOrUpdate(timeSpecificationDtoPeriod.Start, (existingEntity as DbTimeSpecificationPeriod)?.Start?.Moment, x => x.ToDbTimeSpecificationMoment());
          AddOrUpdate(timeSpecificationDtoPeriod.End, (existingEntity as DbTimeSpecificationPeriod)?.End?.Moment, x => x.ToDbTimeSpecificationMoment());
        }
        AddOrUpdate(entity, existingEntity, x => x.ToDbTimeSpecification());
      }
      foreach (var existingConnection in existingTimeSpecificationConnections ?? [])
      {
        if (timeSpecifications.All(x => x.EntityId != onGetExistingEntity(existingConnection).EntityId))
        {
          if (onGetExistingEntity(existingConnection) is DbTimeSpecificationPeriod dbTimeSpecificationPeriod)
          {
            Remove(dbTimeSpecificationPeriod.Start);
            Remove(dbTimeSpecificationPeriod.Start?.Moment);
            Remove(dbTimeSpecificationPeriod.End);
            Remove(dbTimeSpecificationPeriod.End?.Moment);
          }
          Remove(existingConnection);
          Remove(onGetExistingEntity(existingConnection));
        }
      }
    }

    private void RemoveRelatedEntities<TConnection, TDbEntity>(
      TConnection[]? existingEntityConnections,
      Func<TConnection, TDbEntity> onGetExistingEntity, Func<TConnection, TConnection> onGetConnectionWithoutRelatedEntites, Func<TDbEntity, TDbEntity> onGetEntityWithoutRelatedEntites)
      where TDbEntity : DbEntityWithId where TConnection : class
    {
      UpdateRelatedEntities<BaseEntityWithIdDto, TConnection, TDbEntity>([], existingEntityConnections, null, onGetExistingEntity, onGetConnectionWithoutRelatedEntites, onGetEntityWithoutRelatedEntites);
    }
    private void UpdateRelatedEntities<TDto, TConnection, TDbEntity>(TDto[] entities, TConnection[]? existingEntityConnections,
      Func<TDto, TDbEntity>? onGetDbEntity, Func<TConnection, TDbEntity> onGetExistingEntity, Func<TConnection, TConnection> onGetConnectionWithoutRelatedEntites, Func<TDbEntity, TDbEntity> onGetEntityWithoutRelatedEntites)
      where TDto : BaseEntityWithIdDto where TDbEntity : DbEntityWithId where TConnection : class
    {
      foreach (var entity in entities)
      {
        var existingEntityConnection = existingEntityConnections?.FirstOrDefault(x => onGetExistingEntity(x).EntityId == entity.EntityId);
        var existingEntity = existingEntityConnection != null ? onGetExistingEntity(existingEntityConnection) : null;

        if (onGetDbEntity != null)
        {
          AddOrUpdate(entity, existingEntity, x => onGetDbEntity(x));
        }
      }
      foreach (var existingEntityConnection in existingEntityConnections ?? [])
      {
        if (entities.All(x => x.EntityId != onGetExistingEntity(existingEntityConnection).EntityId))
        {
          Remove(onGetConnectionWithoutRelatedEntites(existingEntityConnection));
          Remove(onGetEntityWithoutRelatedEntites(onGetExistingEntity(existingEntityConnection)));
        }
      }
    }
    
    private void SaveDescriptionSpecification(DescriptionSpecificationDto[] descriptionSpecifications, DbDescriptionSpecificationProjectConnection[] existingDescriptionSpecificationConnections)
    {
        foreach (var entity in descriptionSpecifications)
        {
            var existingEntityConnection = existingDescriptionSpecificationConnections?.FirstOrDefault(x => x.EntityId == entity.EntityId);
            var existingEntity = existingEntityConnection?.DescriptionSpecification;
            
            AddOrUpdate(entity, existingEntity, x => x.ToDbDescriptionSpecification());
        }
        foreach (var existingEntityConnection in existingDescriptionSpecificationConnections ?? [])
        {
            if (descriptionSpecifications.All(x => x.EntityId != existingEntityConnection.DescriptionSpecificationId))
            {
                Remove(existingEntityConnection);
                Remove(existingEntityConnection.DescriptionSpecification);
            }
        }
    }

    private void AddOrUpdate<T1, T2>(T1? entity, T2? existingEntity, Func<T1, T2> toDbEntity)
    where T1 : BaseEntityWithIdDto where T2 : DbEntityWithId
    {
        if (entity != null)
        {
            dbContext.AddOrUpdate(toDbEntity(entity), existingEntity);
        }
    }
    private void AddOrUpdateProject(ProjectDto entity, DbProject? existingEntity)
    {
        UpdateHistory(entity.History, existingEntity?.History);
        dbContext.AddOrUpdate(entity.ToDbProject(), existingEntity);
    }
}
