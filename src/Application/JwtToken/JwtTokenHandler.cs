using Application.Common;
using Application.Services;
using System.Security.Cryptography;

namespace Application.JwtToken;

public sealed class JwtTokenHandler(JwtAuthenticationDataService jwtAuthenticationDataService, IServiceProvider serviceProvider, IRefreshTokenRepositoryService refreshTokenRepositoryService) : BaseHandler<JwtTokenRequest, JwtTokenResponse>(serviceProvider)
{
    public override async Task<JwtTokenResponse> ExecuteAsync(JwtTokenRequest command, CancellationToken ct)
    {
        var user = await UserDataService.GetActiveUserByEMail(command.Email, ct);
        if (user == null)
            return new JwtTokenUserNotFoundResponse(command.Email);
        
        await Task.Delay(RandomNumberGenerator.GetInt32(200, 1001), ct);
        
        if (!user.VerifyPassword(command.Password))
            return new JwtTokenWrongPasswordResponse();
        
        var (jwtToken, expiration) = jwtAuthenticationDataService.GenerateJwtToken(user);
        return new JwtTokenSuccessResponse
        {
            Token = jwtToken, 
            ExpiresUtc = expiration,
            RefreshToken = await refreshTokenRepositoryService.GetRenewedRefreshTokenStringIfNecessary(user.EntityId, ct)
        };
    }
}
