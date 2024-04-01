using Application.Services;
using Infrastructure.Services;
using WebApi.Constants;

namespace WebApi.Middlewares;

public class GlobalAccessMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context, IGlobalAccessCookieService globalAccessCookieService)
    {
        if (string.Equals(context.Request.Path.Value?.Trim('/'), Routes.RegisterGlobalAccessCookie.Trim('/'),
                StringComparison.Ordinal))
        {
            await next(context);
            return;
        }
            
        
        if (!globalAccessCookieService.GlobalAccessCookieIsValid())
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            return;
        }
        await next(context);
    }
}

public static class GlobalAccessMiddlewareExtensions
{
    public static IApplicationBuilder UseGlobalAccessMiddlewareIfEnabled(
        this IApplicationBuilder builder, IConfiguration configuration)
    {
        return !GlobalAccessCookieService.IsEnabled(configuration)
            ? builder
            : builder.UseMiddleware<GlobalAccessMiddleware>();
    }
}