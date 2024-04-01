using Application.Services;
using Common;

namespace WebApi.Services;

public class CookieService(IHttpContextAccessor httpContextAccessor) : ICookieService
{
    public void SaveCookie(string cookieName, string cookieValue)
    {
        var httpContext = ThrowIf.Null(httpContextAccessor.HttpContext);
        httpContext.Response.Cookies.Append(cookieName, cookieValue);    
    }
    public string? GetCookie(string cookieName)
    {
        var httpContext = ThrowIf.Null(httpContextAccessor.HttpContext);
        return httpContext.Request.Cookies[cookieName];
    }
}