using Application;
using Azure.Monitor.OpenTelemetry.AspNetCore;
using FastEndpoints;
using FastEndpoints.Swagger;
using Infrastructure;
using Infrastructure.Data;
using OpenTelemetry.Resources;
using Serilog;
using WebApi;
using WebApi.Common;
using WebApi.Constants;
using WebApi.HealthChecks;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddConfiguration(builder.Environment);
builder.Logging.ClearProviders();
if (!builder.Configuration.IsInCodeGenerationMode() && builder.Configuration.UseAzureMonitor())
{
    builder.Services.AddOpenTelemetry().UseAzureMonitor().ConfigureResource(x =>
    {
        x.AddAttributes(new Dictionary<string, object> { { "service.name", "my-service" } });
    });;
}
builder.AddLogging();

if (!builder.Configuration.IsInCodeGenerationMode())
{
    builder.Services.AddApplication();
    builder.Services.AddInfrastructure(builder.Configuration, builder.Environment);
}

builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<CustomExceptionHandler>();
builder.Services.AddWebApi(builder.Configuration);
builder.Services.AddSingleton<StartupHealthCheck>();
builder.Services.AddHealthChecks().AddCheck<StartupHealthCheck>("Startup", tags: [StartupHealthCheck.ReadyTag]);
builder.Services.AddHostedService<StartupBackgroundService>();

var app = builder.Build();
app.UseExceptionHandler();
if (!builder.Configuration.IsInCodeGenerationMode())
{
    app.UseSerilogRequestLogging();
    await app.InitializeDatabaseAsync();
}

app.UseCors(CorsPolicies.AllowAll);

if (!builder.Configuration.IsInCodeGenerationMode())
{
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapHealthChecks();
}

app.UseFastEndpoints();
app.UseSwaggerGen();
app.Run();
