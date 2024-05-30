using Application.Selectors;
using Infrastructure.Data.DbEntities;

namespace Infrastructure.SelectorExtensions;

public static class ProjectSelectorExtensions
{
    public static IQueryable<DbProject> Select(this ProjectSelector projectSelector, IQueryable<DbProject> query)
    {
        return query;
    }
}