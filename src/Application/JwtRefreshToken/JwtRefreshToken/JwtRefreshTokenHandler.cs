using System.IdentityModel.Tokens.Jwt;
using Application.Common;
using Application.Services;
using Common;
using Microsoft.IdentityModel.Tokens;

namespace Application.JwtRefreshToken.JwtRefreshToken;

public sealed class JwtRefreshTokenHandler(IServiceProvider serviceProvider, JwtAuthenticationDataService jwtAuthenticationDataService, IRefreshTokenRepositoryService refreshTokenRepositoryService, IUserDataService userDataService) : BaseHandler<JwtRefreshTokenRequest, JwtRefreshTokenResponse>(serviceProvider)
{
    public override async Task<JwtRefreshTokenResponse> ExecuteAsync(JwtRefreshTokenRequest command, CancellationToken ct)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = jwtAuthenticationDataService.SigningKey.Key,
            ClockSkew = TimeSpan.Zero
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var result = await tokenHandler.ValidateTokenAsync(command.Token, tokenValidationParameters);
        if (!result.IsValid)
            return new JwtRefreshTokenInvalidTokenResponse();
        var userData = result.ClaimsIdentity.ToUserData();

        var storedRefreshToken = await refreshTokenRepositoryService.GetSavedRefreshToken(userData.UserId, ct);
        if (storedRefreshToken == null)
            return new JwtRefreshTokenMissingResponse();

        if (storedRefreshToken.RefreshToken != command.RefreshToken)
            return new JwtRefreshTokenInvalidRefreshTokenResponse();
        
        if(storedRefreshToken.AbsoluteExpirationUtc < DateTimeOffset.UtcNow)
            return new JwtRefreshTokenExpiredResponse();

        var user = ThrowIf.Null(await userDataService.GetActiveUserById(userData.UserId, ct));
        var (jwtToken, expiration) = jwtAuthenticationDataService.GenerateJwtToken(user);
        
        return new JwtRefreshTokenSuccessResponse()
        {
            Token = jwtToken, 
            ExpiresUtc = expiration,
            RefreshToken = await refreshTokenRepositoryService.GetRenewedRefreshTokenString(user.EntityId, ct)
        };

    }
}
