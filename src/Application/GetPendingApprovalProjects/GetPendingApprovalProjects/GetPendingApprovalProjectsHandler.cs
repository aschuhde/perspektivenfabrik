using Application.Common;
using Application.Mapping;
using Application.Messages;
using Application.Services;

namespace Application.GetPendingApprovalProjects.GetPendingApprovalProjects;

public sealed class GetPendingApprovalProjectsHandler(IServiceProvider serviceProvider, IUserAccessService userAccessService, IProjectService projectService) : BaseHandler<GetPendingApprovalProjectsRequest, GetPendingApprovalProjectsResponse>(serviceProvider)
{
    public override async Task<GetPendingApprovalProjectsResponse> ExecuteAsync(GetPendingApprovalProjectsRequest command, CancellationToken ct)
    {
        if (!userAccessService.CanApproveProject())
        {
            return new GetPendingApprovalProjectsNotAllowedResponse(ProjectMessages.GetPendingApprovalProjectsNotAllowedResponse());
        }
        
        var projects = command.IncludeRejectedAndApproved
            ? (await projectService.GetAllApprovalProjects(command.Filter, command.Selector, ct))
            .Select(x => x.ToApiProject()).ToArray()
            : (await projectService.GetPendingApprovalProjects(command.Filter, command.Selector, ct))
            .Select(x => x.ToApiProject()).ToArray();
        return new GetPendingApprovalProjectsOkResponse()
        {
            Projects = projects
        };
    }
}
