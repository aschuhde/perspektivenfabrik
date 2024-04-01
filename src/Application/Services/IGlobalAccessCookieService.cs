namespace Application.Services;

public interface IGlobalAccessCookieService
{
    bool GlobalAccessCookieIsValid();
    bool GlobalAccessCookieIsValid(string token);
    void SaveCookie(string token);
}