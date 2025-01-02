namespace Infrastructure.Data;

public static class ApplicationDbContextExtensions
{
    public static void AddOrUpdate<TEntity>(this ApplicationDbContext dbContext, TEntity entity, bool entityExists)
    {
        if (entity == null)
        {
            return;
        }
        if (entityExists)
        {
            dbContext.Update(entity);
        }
        else
        {
            dbContext.Add(entity);
        }
    }
}
