using Application.Common;

namespace Application.JwtToken;

public class JwtTokenRequest : BaseRequest<JwtTokenResponse>
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}
