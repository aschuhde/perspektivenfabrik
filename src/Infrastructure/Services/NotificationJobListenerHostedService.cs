using Microsoft.Extensions.Hosting;

namespace Infrastructure.Services;

public class NotificationJobListenerHostedService(NotificationStorageService notificationStorageService) : BackgroundService
{
  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    while (!stoppingToken.IsCancellationRequested)
    {
      await notificationStorageService.HandleIncomingNotification(stoppingToken);
    }
  }
}
