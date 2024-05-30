using Application.Filter;
using Application.Mapping;
using Application.Models.ApiModels;
using Application.Models.ProjectService;
using Application.Selectors;
using Application.Services;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Data;
using Infrastructure.Data.DbEntities;
using Infrastructure.Data.Mapping;
using Infrastructure.FilterExtensions;
using Infrastructure.SelectorExtensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class ProjectService(ApplicationDbContext dbContext) : IProjectService
{
    private async Task<ProjectDto[]> GetProjects(Func<IQueryable<DbProject>, IQueryable<DbProject>> filterFunction, Func<IQueryable<DbProject>, IQueryable<DbProject>> selectFunction, CancellationToken ct)
    {
        return (await selectFunction(filterFunction(dbContext.Projects)).AsNoTracking().ToArrayAsync(ct)).Select(x => x.ToProject()).ToArray();
    }

    public async Task<ProjectDto[]> GetPublicProjects(ProjectFilter? projectFilter, ProjectSelector? projectSelector, CancellationToken cr)
    {
        return await GetProjects(query =>
            (projectFilter ?? EmptyFilterCreator.CreateEmptyProjectFilter()).Filter(query.Where(x =>
                x.Visibility == ProjectVisibility.Public)), query => 
            (projectSelector ?? DefaultSelectorCreator.CreateDefaultProjectSelector()).Select(query), ct);
    }

    public async Task<CreateProjectResult> CreateProject(ProjectDto project, CancellationToken ct)
    {
        var dbEntity = project.ToDbProject();
        await dbContext.Projects.AddAsync(dbEntity, ct);
        await dbContext.SaveChangesAsync(ct);
        var resultProject = (await GetProjects(query => query.Where(x => x.EntityId == dbEntity.EntityId), query => query, ct)).FirstOrDefault();
    }
}