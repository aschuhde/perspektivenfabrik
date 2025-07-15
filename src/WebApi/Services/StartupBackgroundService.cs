using WebApi.HealthChecks;

namespace WebApi.Services;

public class StartupBackgroundService(StartupHealthCheck startupHealthCheck) : BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        startupHealthCheck.StartupCompleted = true;
        return Task.CompletedTask;
    }
}