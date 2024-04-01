using Application.Common;
using Application.Services;

namespace Application.RegisterGlobalAccessCookie.RegisterGlobalAccessCookie;

public class RegisterGlobalAccessCookieHandler(IServiceProvider serviceProvider, IGlobalAccessCookieService globalAccessCookieService) : BaseHandler<RegisterGlobalAccessCookieRequest, RegisterGlobalAccessCookieResponse>(serviceProvider)
{
    public override Task<RegisterGlobalAccessCookieResponse> ExecuteAsync(RegisterGlobalAccessCookieRequest command, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(command.GlobalAccessCookie))
            return Task.FromResult<RegisterGlobalAccessCookieResponse>(new RegisterGlobalAccessCookieResponseEmptyToken());
        
        if (!globalAccessCookieService.GlobalAccessCookieIsValid(command.GlobalAccessCookie))
            return Task.FromResult<RegisterGlobalAccessCookieResponse>(new RegisterGlobalAccessCookieResponseInvalidToken());
        
        globalAccessCookieService.SaveCookie(command.GlobalAccessCookie);
        
        return Task.FromResult<RegisterGlobalAccessCookieResponse>(new RegisterGlobalAccessCookieSuccessResponse());
    }
}
