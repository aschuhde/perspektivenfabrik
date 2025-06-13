using Application.Common;
using Application.Mapping;
using Application.Services;
using Domain.Enums;

namespace Application.GetProject.GetProject;

public class GetProjectHandler(IServiceProvider serviceProvider, IProjectService projectService) : BaseHandler<GetProjectRequest, GetProjectResponse>(serviceProvider)
{
    public override async Task<GetProjectResponse> ExecuteAsync(GetProjectRequest command, CancellationToken ct)
    {
        var projectDto = await projectService.GetProjectById(Guid.Parse(command.ProjectIdentifier), ct);
        var project = projectDto?.ToApiProject();
        if (project == null)
        {
            return new GetProjectResponseNotFound();
        }

        if (project.Visibility != ProjectVisibility.Public
            || (project.ApprovalStatus != ApprovalStatus.Approved
                && project.ApprovalStatus != ApprovalStatus.AutoApproved))
        {
            return new GetProjectResponseForbidden();
        }
        return new GetProjectResponseSuccess()
        {
            Project = project
        };
    }
}
