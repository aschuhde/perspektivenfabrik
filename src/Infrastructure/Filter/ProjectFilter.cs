using Infrastructure.Data.DbEntities;

namespace Infrastructure.Filter;

public class ProjectFilter
{
    public IQueryable<DbProject> Filter(IQueryable<DbProject> query)
    {
        return query;
    }
}