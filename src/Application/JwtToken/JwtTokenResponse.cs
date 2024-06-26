using System.Net;
using Application.Common.Response;
using Application.Messages;

namespace Application.JwtToken;

public class JwtTokenResponse : JsonResponse
{
    public string? Token { get; init; }
    public string? RefreshToken { get; init; }
    public DateTimeOffset? ExpiresUtc { get; init; }
}

public sealed class JwtTokenSuccessResponse : JwtTokenResponse
{
    
}

public sealed class JwtTokenUserNotFoundResponse : JwtTokenResponse
{
    public JwtTokenUserNotFoundResponse(string email)
    {
        Error = new ErrorResponseData() { Message = UserMessages.UserByMailNotFound(email) };
        StatusCode = HttpStatusCode.NotFound;
    }
}

public sealed class JwtTokenWrongPasswordResponse : JwtTokenResponse
{
    public JwtTokenWrongPasswordResponse()
    {
        Error = new ErrorResponseData() { Message = UserMessages.UserWrongPassword() };
        StatusCode = HttpStatusCode.BadRequest;
    }
}
