using Application.Common;
using Application.Configuration;
using Application.Services;
using Common;
using Domain.Enums;
using Microsoft.Extensions.Configuration;

namespace Application.PostRequestOtp.PostRequestOtp;

public sealed class PostRequestOtpHandler(IServiceProvider serviceProvider, IOtpService otpService, IUserDataService userDataService, IConfiguration configuration) : BaseHandler<PostRequestOtpRequest, PostRequestOtpResponse>(serviceProvider)
{
    public override async Task<PostRequestOtpResponse> ExecuteAsync(PostRequestOtpRequest command, CancellationToken ct)
    {
        var user = ThrowIf.Null(await userDataService.GetActiveUserById(CurrentUserId, ct));
        if (user.EmailConfirmed)
        {
            return new PostRequestOtpNotRequiredResponse();
        }
        var openOtps = await otpService.GetOpenOtps(CurrentUserId, ct);
        var options = configuration.GetOtpOptions();
        var pendingOtps = openOtps.Where(x => x.Status == OtpStatus.Pending).ToArray();
        if (pendingOtps.Length > 0)
        {
            var lastRequestSent = pendingOtps.Max(x => x.RequestedOnUtc);
            var secondsFromLastRequest = (int)(DateTime.UtcNow - lastRequestSent).TotalSeconds;
            if(secondsFromLastRequest < options.SecondsToWaitForNewRequest)
            {
                return new PostRequestOtpPleaseWaitResponse(options.SecondsToWaitForNewRequest - secondsFromLastRequest);
            }
        }
        
        await otpService.CreateOtp(CurrentUserId, ct);
        return new PostRequestOtpOkResponse();
    }
}
