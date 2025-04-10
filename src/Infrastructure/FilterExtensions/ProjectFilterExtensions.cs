using Application.Filter;
using Infrastructure.Data.DbEntities;

namespace Infrastructure.FilterExtensions;

public static class ProjectFilterExtensions
{
    public static IQueryable<DbProject> Filter(this ProjectFilter projectFilter, IQueryable<DbProject> query)
    {
        return query;
    }
}