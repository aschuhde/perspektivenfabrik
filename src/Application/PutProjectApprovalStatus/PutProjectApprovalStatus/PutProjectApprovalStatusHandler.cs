using Application.Common;
using Application.Models.ProjectService;
using Application.Services;

namespace Application.PutProjectApprovalStatus.PutProjectApprovalStatus;

public sealed class PutProjectApprovalStatusHandler(IServiceProvider serviceProvider, IProjectService projectService) : BaseHandler<PutProjectApprovalStatusRequest, PutProjectApprovalStatusResponse>(serviceProvider)
{
    public override async Task<PutProjectApprovalStatusResponse> ExecuteAsync(PutProjectApprovalStatusRequest command, CancellationToken ct)
    {
        if (!UserAccessService.CanApproveProject())
        {
            return new PutProjectApprovalStatusNotAllowedResponse(Messages.ProjectMessages.PutProjectApprovalStatusNotAllowedResponse(command.EntityId));
        }
        
        var result = await projectService.UpdateProjectApprovalStatus(command.Data.ApprovalStatus, command.EntityId, CurrentUserService.DisplayName, command.Data.Reason);

        return result switch
        {
            ApproveProjectResult.ProjectNotFound => new PutProjectApprovalStatusNotFoundResponse(Messages.ProjectMessages.EntityNotFound(command.EntityId)),
            ApproveProjectResult.Ok => new PutProjectApprovalStatusOk(),
            ApproveProjectResult.NotModified => new PutProjectApprovalStatusAlreadyApproved(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
