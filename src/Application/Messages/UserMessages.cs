using System.Globalization;
using Common;

namespace Application.Messages;

public static class UserMessages
{
    
    public static Message UrlNotFound() => new($"The requested url was not found!");
    public static Message UserByMailNotFound(string email) => new($"No user with email {email} was found!",
        nameof(UserByMailNotFound));
    
    public static Message UserWrongPassword() => new($"The entered credentials are not correct!",
        nameof(UserWrongPassword));
    
    public static Message UserInvalidToken() => new($"The provided token is not valid!",
        nameof(UserInvalidToken));
    
    public static Message UserInvalidRefreshToken() => new($"The provided refresh token is not valid!",
        nameof(UserInvalidRefreshToken));
    
    public static Message UserRefreshTokenMissing() => new($"For this user, no active refresh token is stored. Please log-in again!",
        nameof(UserRefreshTokenMissing));
    
    public static Message UserRefreshTokenExpired() => new($"The refresh token expired. Please log-in again!",
        nameof(UserRefreshTokenExpired));
    
    public static Message PasswordNeedsUppercaseLetter()  =>
        CultureInfo.CurrentUICulture.TwoLetterISOLanguageName switch
        {
            "de" => new("Das Passwort muss mindestens einen Großbuchstaben enthalten"),
            "it" => new("La password deve contenere almeno una lettera maiuscola"),
            _ => new("Password must contain at least one uppercase letter")
        };
    
    public static Message PasswordNeedsLowercaseLetter()  =>
        CultureInfo.CurrentUICulture.TwoLetterISOLanguageName switch
        {
            "de" => new("Das Passwort muss mindestens einen Kleinbuchstaben enthalten"),
            "it" => new("La password deve contenere almeno una lettera minuscola"),
            _ => new("Password must contain at least one lowercase letter")
        };
    
    public static Message PasswordNeedsNumber()  =>
        CultureInfo.CurrentUICulture.TwoLetterISOLanguageName switch
        {
            "de" => new("Das Passwort muss mindestens eine Zahl enthalten"),
            "it" => new("La password deve contenere almeno un numero"),
            _ => new("Password must contain at least one number")
        };

    public static Message PasswordNeedsSpecialCharacter(string specialChars) =>
        CultureInfo.CurrentUICulture.TwoLetterISOLanguageName switch
        {
            "de" => new($"Das Passwort muss mindestens eins der folgenden Sonderzeichen beinhalten: {specialChars}"),
            "it" => new($"La password deve contenere almeno uno dei seguenti caratteri speciali: {specialChars}"),
            _ => new($"Password must contain at least one special character of the followings: {specialChars}")
        };
}
