using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ConfigureServices
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<JwtAuthenticationDataService>();
    }
}
