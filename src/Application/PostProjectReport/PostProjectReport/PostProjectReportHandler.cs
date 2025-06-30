using Application.Common;
using Application.Services;

namespace Application.PostProjectReport.PostProjectReport;

public sealed class PostProjectReportHandler(IServiceProvider serviceProvider, INotificationService notificationService) : BaseHandler<PostProjectReportRequest, PostProjectReportResponse>(serviceProvider)
{
    public override Task<PostProjectReportResponse> ExecuteAsync(PostProjectReportRequest command, CancellationToken ct)
    {
        notificationService.ProjectReported(command.EntityId, command.Data.Reason, CurrentUserId, CurrentUserService.DisplayName);
        
        return Task.FromResult(new PostProjectReportResponse() { });
    }
}
