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

        var result = await projectService.ApproveProject(command.EntityId, CurrentUserService.DisplayName);

        return result switch
        {
            ApproveProjectResult.ProjectNotFound => new PutProjectApprovalStatusNotFoundResponse(Messages.ProjectMessages.EntityNotFound(command.EntityId)),
            ApproveProjectResult.Ok => new PutProjectApprovalStatusOk(),
            ApproveProjectResult.AlreadyApproved => new PutProjectApprovalStatusAlreadyApproved(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
