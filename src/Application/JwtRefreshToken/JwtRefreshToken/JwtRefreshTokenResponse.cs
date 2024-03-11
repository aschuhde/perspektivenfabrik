using System.Net;
using Application.Common.Response;
using Application.Messages;

namespace Application.JwtRefreshToken.JwtRefreshToken;

public class JwtRefreshTokenResponse : JsonResponse
{
    public string? Token { get; init; }
    public string? RefreshToken { get; init; }
    public DateTimeOffset? ExpiresUtc { get; init; }
}

public class JwtRefreshTokenSuccessResponse : JwtRefreshTokenResponse
{
    
}
public class JwtRefreshTokenInvalidTokenResponse : JwtRefreshTokenResponse
{
    public JwtRefreshTokenInvalidTokenResponse()
    {
        Error = new ErrorResponseData() { Message = UserMessages.UserInvalidToken() };
        StatusCode = HttpStatusCode.Unauthorized;
    }
}

public class JwtRefreshTokenMissingResponse : JwtRefreshTokenResponse
{
    public JwtRefreshTokenMissingResponse()
    {
        Error = new ErrorResponseData() { Message = UserMessages.UserRefreshTokenMissing() };
        StatusCode = HttpStatusCode.Unauthorized;
    }
}

public class JwtRefreshTokenExpiredResponse : JwtRefreshTokenResponse
{
    public JwtRefreshTokenExpiredResponse()
    {
        Error = new ErrorResponseData() { Message = UserMessages.UserRefreshTokenExpired() };
        StatusCode = HttpStatusCode.Unauthorized;
    }
}

public class JwtRefreshTokenInvalidRefreshTokenResponse : JwtRefreshTokenResponse
{
    public JwtRefreshTokenInvalidRefreshTokenResponse()
    {
        Error = new ErrorResponseData() { Message = UserMessages.UserInvalidRefreshToken() };
        StatusCode = HttpStatusCode.Unauthorized;
    }
}

