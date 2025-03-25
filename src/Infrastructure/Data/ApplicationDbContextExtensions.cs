using Infrastructure.Data.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public static class ApplicationDbContextExtensions
{
    public static void AddOrUpdate<TEntity>(this ApplicationDbContext dbContext, TEntity? entity, TEntity? existingEntity)
    where TEntity : DbEntityWithId
    {
        if (entity == null)
        {
            return;
        }
        if (existingEntity != null)
        {
            existingEntity.UpdateToTarget(entity);
        }
        else
        {
            dbContext.Add(entity);
        }
    }

    public static IQueryable<T> WithAsNoTrackingIfEnabled<T>(this IQueryable<T> query, bool withTracking) where T : class
    {
      if (withTracking)
      {
        return query;
      }

      return query.AsNoTracking();
    }
    public static void PutNewEntriesInAddedState(this ApplicationDbContext dbContext)
    {
        foreach (var entry in dbContext.ChangeTracker.Entries<DbEntityWithId>())
        {
            if (entry.State != EntityState.Modified) continue;
            
            entry.State = entry.Entity.IsNewEntity ? EntityState.Added : EntityState.Modified;
        }
    }
}
