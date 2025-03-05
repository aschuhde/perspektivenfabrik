using Infrastructure.Data.DbEntities;

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
}
