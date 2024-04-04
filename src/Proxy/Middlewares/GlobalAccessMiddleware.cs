using Common;
using Proxy.Common;

namespace Proxy.Middlewares;

public class GlobalAccessMiddleware(RequestDelegate next)
{
    private const string ConfigurationSection = "GlobalAccessSecurity";
    private const string CookieName = "global-access-cookie";
    private void SaveCookie(string cookieName, string cookieValue, HttpContext httpContext)
    {
        httpContext.Response.Cookies.Append(cookieName, cookieValue);    
    }
    private string? GetCookie(string cookieName, HttpContext httpContext)
    {
        return httpContext.Request.Cookies[cookieName];
    }
    private bool GlobalAccessCookieIsValid(HttpContext context, IConfiguration configuration)
    {
        var cookie = GetGlobalAccessCookie(context);
        if (string.IsNullOrWhiteSpace(cookie))
            return false;
        return GlobalAccessCookieIsValid(cookie, configuration);
    }
    private bool GlobalAccessCookieIsValid(string token, IConfiguration configuration)
    {
        var tokenToValidate = ThrowIf.NullOrWhitespace(token);
        var globalAccessToken = ThrowIf.NullOrWhitespace(configuration[$"{ConfigurationSection}:Token"]);
        return string.Equals(globalAccessToken, tokenToValidate, StringComparison.Ordinal);
    }

    private string? GetGlobalAccessCookie(HttpContext context) => GetCookie(CookieName, context);
    public async Task InvokeAsync(HttpContext context, IConfiguration configuration)
    {
        if (string.Equals(context.Request.Path.Value?.Trim('/'), Routes.GlobalAccessTokenRegister.Trim('/'),
                StringComparison.Ordinal))
        {
            var token = context.Request.Query["token"].ToString();
            if (string.IsNullOrWhiteSpace(token))
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                return;
            }
            if (!GlobalAccessCookieIsValid(token, configuration))
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                return;
            }
            SaveCookie(CookieName, token, context);
            context.Response.Redirect("/home");
            return;
        }
        
        if (!GlobalAccessCookieIsValid(context, configuration))
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            return;
        }
        await next(context);
    }
    internal static bool IsEnabled(IConfiguration configuration) => configuration.GetValue<bool?>($"{ConfigurationSection}:Enabled") == true;
}

public static class GlobalAccessMiddlewareExtensions
{
    public static IApplicationBuilder UseGlobalAccessMiddlewareIfEnabled(
        this IApplicationBuilder builder, IConfiguration configuration)
    {
        return !GlobalAccessMiddleware.IsEnabled(configuration)
            ? builder
            : builder.UseMiddleware<GlobalAccessMiddleware>();
    }
}