using Application.Services;
using Common;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure;

public static class ConfigureServices
{
    public static string? GetDefaultConnectionString(this IConfiguration configuration) =>
        configuration.GetConnectionString("default");
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
    {
        var connectionString = ThrowIf.NullOrWhitespace(configuration.GetDefaultConnectionString(),
            "No connection string is configured");
        
        services.AddScoped<ApplicationDbContextInitializer>();
        services.AddScoped<IUserDataService, UserDataService>();
        services.AddScoped<IRefreshTokenRepositoryService, RefreshTokenRepositoryService>();
        services.AddScoped<IProjectService, ProjectService>();
        services.AddScoped<IOtpService, OtpService>();
        services.AddDbContext<ApplicationDbContext>((_, builder) =>
        {
            builder.UseNpgsql(connectionString);
            if (environment.IsDevelopment())
                builder.EnableSensitiveDataLogging();
        });
    }
}
