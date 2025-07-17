using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace WebApi.HealthChecks;

public class StartupHealthCheck : IHealthCheck
{
    private volatile bool _isReady;
    public const string ReadyTag = "ready";
    public bool StartupCompleted
    {
        get => _isReady;
        set => _isReady = value;
    }
    
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
    {
        if (StartupCompleted)
        {
            return Task.FromResult(HealthCheckResult.Healthy("The startup task has completed."));
        }

        return Task.FromResult(HealthCheckResult.Unhealthy("That startup task is still running."));
    }
}