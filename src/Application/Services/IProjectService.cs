using Application.Filter;
using Application.Models.ProjectService;
using Application.Selectors;
using Application.Updaters;
using Domain.Entities;

namespace Application.Services;

public interface IProjectService
{
    public Task<ProjectDto[]> GetPublicProjects(ProjectFilter? projectFilter, ProjectSelector? projectSelector, CancellationToken ct);
    public Task<ProjectDto?> GetProjectById(Guid entityId, CancellationToken ct);
    public Task<CreateorUpdateProjectResult> CreateOrUpdateProject(ProjectDto project, EntityUpdatingContext changeContext, CancellationToken ct);
}
