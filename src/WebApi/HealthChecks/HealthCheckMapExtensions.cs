using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace WebApi.HealthChecks;

public static class HealthCheckMapExtensions
{
    public static void MapHealthChecks(this WebApplication app)
    {
        app.MapHealthChecks("/healthz/ready", new HealthCheckOptions
        {
            Predicate = healthCheck => healthCheck.Tags.Contains(StartupHealthCheck.ReadyTag)
        });

        app.MapHealthChecks("/healthz/live", new HealthCheckOptions
        {
            Predicate = healthCheck => !healthCheck.Tags.Contains(StartupHealthCheck.ReadyTag)
        });
    }
}