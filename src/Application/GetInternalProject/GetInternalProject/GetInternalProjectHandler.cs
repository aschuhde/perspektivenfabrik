using Application.Common;
using Application.Mapping;
using Application.Services;
using Domain.Enums;

namespace Application.GetInternalProject.GetInternalProject;

public class GetInternalProjectHandler(IServiceProvider serviceProvider, IProjectService projectService) : BaseHandler<GetInternalProjectRequest, GetInternalProjectResponse>(serviceProvider)
{
    public override async Task<GetInternalProjectResponse> ExecuteAsync(GetInternalProjectRequest command, CancellationToken ct)
    {
        var projectDto = await projectService.GetProjectById(Guid.Parse(command.ProjectIdentifier), ct);
        var project = projectDto?.ToApiProject();
        if (project == null)
        {
            return new GetInternalProjectResponseNotFound();
        }
        
        if (project.Visibility != ProjectVisibility.Internal && project.Visibility != ProjectVisibility.Public)
        {
            return new GetInternalProjectResponseForbidden();
        }
        return new GetInternalProjectResponseSuccess()
        {
            Project = project
        };
    }
}
