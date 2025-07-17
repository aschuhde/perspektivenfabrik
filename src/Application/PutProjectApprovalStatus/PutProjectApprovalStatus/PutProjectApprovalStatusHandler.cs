using Application.Common;
using Application.Models.ProjectService;
using Application.Services;
using Domain.Enums;

namespace Application.PutProjectApprovalStatus.PutProjectApprovalStatus;

public sealed class PutProjectApprovalStatusHandler(IServiceProvider serviceProvider, IProjectService projectService, INotificationService notificationService) : BaseHandler<PutProjectApprovalStatusRequest, PutProjectApprovalStatusResponse>(serviceProvider)
{
    public override async Task<PutProjectApprovalStatusResponse> ExecuteAsync(PutProjectApprovalStatusRequest command, CancellationToken ct)
    {
        if (!UserAccessService.CanApproveProject())
        {
            return new PutProjectApprovalStatusNotAllowedResponse(Messages.ProjectMessages.PutProjectApprovalStatusNotAllowedResponse(command.EntityId));
        }
        
        var result = await projectService.UpdateProjectApprovalStatus(command.Data.ApprovalStatus, command.EntityId, CurrentUserService.DisplayName, command.Data.Reason, ct);

        if (result == ApproveProjectResult.Ok && command.Data.ApprovalStatus == ApprovalStatus.Rejected)
        {
            notificationService.ProjectRejected(command.EntityId, command.Data.Reason, CurrentUserService.CurrentUserId, CurrentUserService.DisplayName);
        }else if (result == ApproveProjectResult.Ok && command.Data.ApprovalStatus is ApprovalStatus.Approved or ApprovalStatus.AutoApproved)
        {
            notificationService.ProjectApproved(command.EntityId, command.Data.Reason, CurrentUserService.CurrentUserId, CurrentUserService.DisplayName);
        }
        else
        {
            notificationService.ProjectApprovalWithdrawn(command.EntityId, command.Data.Reason, CurrentUserService.CurrentUserId, CurrentUserService.DisplayName);
        }
        
        return result switch
        {
            ApproveProjectResult.ProjectNotFound => new PutProjectApprovalStatusNotFoundResponse(Messages.ProjectMessages.EntityNotFound(command.EntityId)),
            ApproveProjectResult.Ok => new PutProjectApprovalStatusOk(),
            ApproveProjectResult.NotModified => new PutProjectApprovalStatusAlreadyApproved(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
