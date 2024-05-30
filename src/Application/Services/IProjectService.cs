using Application.Filter;
using Application.Models.ApiModels;
using Application.Models.ProjectService;
using Application.Selectors;
using Domain.Entities;

namespace Application.Services;

public interface IProjectService
{
    public Task<ProjectDto[]> GetPublicProjects(ProjectFilter? projectFilter, ProjectSelector? projectSelector, CancellationToken ct);
    public Task<CreateProjectResult> CreateProject(ProjectDto project, CancellationToken ct);
}