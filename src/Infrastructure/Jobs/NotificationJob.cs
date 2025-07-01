using Infrastructure.Services;
using Quartz;

namespace Infrastructure.Jobs;

public class NotificationJob(NotificationSenderService notificationSenderService) : IJob
{
  public const string Id = nameof(NotificationJob);
  public const string TriggerId = $"{Id}-trigger";
  
  public async Task Execute(IJobExecutionContext context)
  {
      await notificationSenderService.SendPendingNotifications(context.CancellationToken);
  }
}
