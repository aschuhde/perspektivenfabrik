using Application.Common;

namespace Application.JwtToken;

public sealed class JwtTokenRequest : BaseRequest<JwtTokenResponse>
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}
