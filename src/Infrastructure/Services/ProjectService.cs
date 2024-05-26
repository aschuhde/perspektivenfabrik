using Domain.Entities;
using Domain.Enums;
using Infrastructure.Data;
using Infrastructure.Data.DbEntities;
using Infrastructure.Data.Mapping;
using Infrastructure.Filter;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class ProjectService(ApplicationDbContext dbContext)
{
    private async Task<ProjectDto[]> GetProjects(Func<IQueryable<DbProject>, IQueryable<DbProject>> filterFunction)
    {
        return (await filterFunction(dbContext.Projects).AsNoTracking().ToArrayAsync()).Select(x => x.ToProject()).ToArray();
    }

    public async Task<ProjectDto[]> GetPublicProjects(ProjectFilter projectFilter)
    {
        return await GetProjects(query => projectFilter.Filter(query.Where(x => x.Visibility == ProjectVisibility.Public)));
    }
    
    
}