using Application.Services;
using Common;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services;

public class GlobalAccessCookieService(IConfiguration configuration, ICookieService cookieService) : IGlobalAccessCookieService
{
    private const string ConfigurationSection = "GlobalAccessSecurity";
    private const string CookieName = "global-access-cookie";

    public bool GlobalAccessCookieIsValid()
    {
        var cookie = GetGlobalAccessCookie();
        if (string.IsNullOrWhiteSpace(cookie))
            return false;
        return GlobalAccessCookieIsValid(cookie);
    }
    public bool GlobalAccessCookieIsValid(string token)
    {
        var tokenToValidate = ThrowIf.NullOrWhitespace(token);
        var globalAccessToken = ThrowIf.NullOrWhitespace(configuration[$"{ConfigurationSection}:Token"]);
        return string.Equals(globalAccessToken, tokenToValidate, StringComparison.Ordinal);
    }

    private string? GetGlobalAccessCookie() => cookieService.GetCookie(CookieName);

    public void SaveCookie(string token)
    {
        cookieService.SaveCookie(CookieName, token);
    }
    
    public static bool IsEnabled(IConfiguration configuration) => configuration.GetValue<bool?>($"{ConfigurationSection}:Enabled") == true;
}