using Application.Common;

namespace Application.JwtRefreshToken.JwtRefreshToken;

public class JwtRefreshTokenRequest : BaseRequest<JwtRefreshTokenResponse>
{
    public required string Token { get; init; }
    public required string RefreshToken { get; init; }
}

