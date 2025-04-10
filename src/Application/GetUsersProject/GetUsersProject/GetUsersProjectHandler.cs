using Application.Common;
using Application.Mapping;
using Application.Services;
using Domain.Enums;

namespace Application.GetUsersProject.GetUsersProject;

public class GetUsersProjectHandler(IServiceProvider serviceProvider, IProjectService projectService, ICurrentUserService currentUserService) : BaseHandler<GetUsersProjectRequest, GetUsersProjectResponse>(serviceProvider)
{
    public override async Task<GetUsersProjectResponse> ExecuteAsync(GetUsersProjectRequest command, CancellationToken ct)
    {
        var projectDto = await projectService.GetProjectById(Guid.Parse(command.ProjectIdentifier), ct);
        var project = projectDto?.ToApiProject();
        if (project == null)
        {
            return new GetUsersProjectResponseNotFound();
        }

        var userId = currentUserService.CurrentUserId;
        
        if (project.Visibility != ProjectVisibility.Internal && project.Visibility != ProjectVisibility.Public
            && !currentUserService.IsAdmin && project.Contributors.All(x => x.EntityId != userId) && project.Owner?.EntityId != userId)
        {
            return new GetUsersProjectResponseForbidden();
        }
        return new GetUsersProjectResponseSuccess()
        {
            Project = project
        };
    }
}
