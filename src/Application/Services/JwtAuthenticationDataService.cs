using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Application.Common;
using Common;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services;

public class JwtAuthenticationDataService(IConfiguration configuration)
{
    private const int ExpirationMinutes = 5;
    public SigningCredentials SigningKey { get; } = new(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(LoadSigninKey(configuration))),
        SecurityAlgorithms.HmacSha512Signature);
    
    public static string LoadSigninKey(IConfiguration configuration)
    {
        return ThrowIf.NullOrWhitespace(configuration["Jwt:Key"], "Jwt:Key needs to be configured");
    }

    private DateTimeOffset GetExpirationFromNow() => DateTimeOffset.UtcNow.AddMinutes(ExpirationMinutes);
    
    public (string, DateTimeOffset) GenerateJwtToken(User user)
    {
        var expiration = GetExpirationFromNow();
        var signingKey = SigningKey;
        if (signingKey.Key.KeySize < 512)
            throw new SecurityTokenInvalidSigningKeyException($"The jwt signing key is to short and contains only {signingKey.Key.KeySize} bits. Please configure a longer jwt signing key.");
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(new SecurityTokenDescriptor()
        {
            Subject = user.ToClaimsIdentity(),
            Expires = expiration.UtcDateTime,
            SigningCredentials = signingKey
        });
        var jwtToken = tokenHandler.WriteToken(token);
        return (jwtToken, expiration);
    }
}
