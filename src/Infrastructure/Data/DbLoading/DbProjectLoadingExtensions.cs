using Infrastructure.Data.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DbLoading;

public static class DbProjectLoadingExtensions
{
    public static IQueryable<DbProject> IncludeRelatedProjects(
        this IQueryable<DbProject> query) =>
        query.Include(x => x.RelatedProjects!).ThenInclude(x => x.RelatedProject!);
}