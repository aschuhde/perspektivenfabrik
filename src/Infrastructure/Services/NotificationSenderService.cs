namespace Infrastructure.Services;

public class NotificationSenderService(NotificationStorageService notificationStorageService)
{
  public async Task SendPendingNotifications(CancellationToken contextCancellationToken)
  {
      var pendingNotifications = await notificationStorageService.GetPendingNotifications(contextCancellationToken);
  }
}
