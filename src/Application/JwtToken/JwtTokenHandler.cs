using Application.Common;
using Application.Services;

namespace Application.JwtToken;

public class JwtTokenHandler(JwtAuthenticationDataService jwtAuthenticationDataService, IServiceProvider serviceProvider, IRefreshTokenRepositoryService refreshTokenRepositoryService) : BaseHandler<JwtTokenRequest, JwtTokenResponse>(serviceProvider)
{
    public override async Task<JwtTokenResponse> ExecuteAsync(JwtTokenRequest command, CancellationToken ct)
    {
        var user = await UserDataService.GetActiveUserByEMail(command.Email, ct);
        if (user == null)
            return new JwtTokenUserNotFoundResponse(command.Email);

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
