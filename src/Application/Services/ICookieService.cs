namespace Application.Services;

public interface ICookieService
{
    void SaveCookie(string cookieName, string cookieValue);
    string? GetCookie(string cookieName);
}