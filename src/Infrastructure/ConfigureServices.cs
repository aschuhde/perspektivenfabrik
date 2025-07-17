using Application.Configuration;
using Application.Services;
using Common;
using Infrastructure.Data;
using Infrastructure.Jobs;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.AspNetCore;

namespace Infrastructure;

public static class ConfigureServices
{
    public static string? GetDefaultConnectionString(this IConfiguration configuration) =>
        configuration.GetConnectionString("default");
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
    {
        configuration.GetSmtpOptions().Validate();
        configuration.GetNotificationOptions().Validate();
        
        var connectionString = ThrowIf.NullOrWhitespace(configuration.GetDefaultConnectionString(),
            "No connection string is configured");
        
        services.AddScoped<ApplicationDbContextInitializer>();
        services.AddScoped<IUserDataService, UserDataService>();
        services.AddScoped<IRefreshTokenRepositoryService, RefreshTokenRepositoryService>();
        services.AddScoped<IProjectService, ProjectService>();
        services.AddScoped<IOtpService, OtpService>();
        services.AddSingleton<INotificationService, NotificationService>();
        services.AddScoped<MailService>();
        services.AddSingleton<NotificationStorageService>();
        services.AddScoped<NotificationSenderService>();
        services.AddHostedService<NotificationJobListenerHostedService>();
        services.AddDbContext<ApplicationDbContext>((_, builder) =>
        {
            builder.UseNpgsql(connectionString);
            if (environment.IsDevelopment())
                builder.EnableSensitiveDataLogging();
        });
        services.AddHealthChecks().AddDbContextCheck<ApplicationDbContext>();
        
        services.AddQuartz(q =>
        {
            q.AddJob<NotificationJob>(x => x.WithIdentity(NotificationJob.Id));
            q.AddTrigger(x => x.ForJob(NotificationJob.Id)
              .WithIdentity(NotificationJob.TriggerId)
              .WithSimpleSchedule(y => y.RepeatForever()
                .WithIntervalInSeconds(5)));
        });
        
        services.AddQuartzServer(options =>
        {
          options.WaitForJobsToComplete = true;
        });
    }
}
