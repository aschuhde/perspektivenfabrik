using Application.Services;
using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using WebApi.Constants;
using WebApi.Services;

namespace WebApi;

public static class ConfigureServices
{
    public static void AddWebApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEndpointsApiExplorer();

        services.AddHealthChecks();
        
        services.AddFastEndpoints().SwaggerDocument(o =>
        {
            o.EndpointFilter = ep => ep.EndpointTags?.Contains(KnownTags.SwaggerIgnore) is not true;
        });
        services.AddJWTBearerAuth(JwtAuthenticationDataService.LoadSigninKey(configuration));
        services.AddAuthorization();
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.AddScoped<ICookieService, CookieService>();
        services.AddCors(options =>
        {
            options.AddPolicy(CorsPolicies.AllowAll, builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });
    }
}
