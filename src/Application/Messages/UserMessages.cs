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
        nameof(UserRefreshTokenMissing));
    
    public static Message GlobalAccessCookieResponseInvalidToken() => new($"The provided global access cookie is not valid!",
        nameof(GlobalAccessCookieResponseInvalidToken));
    
    public static Message GlobalAccessCookieResponseEmptyToken() => new($"The provided global access cookie is not provided via the query parameter token!",
        nameof(GlobalAccessCookieResponseEmptyToken));
}
