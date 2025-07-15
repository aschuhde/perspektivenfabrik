using Application.Common;
using Application.Configuration;
using Application.Services;
using Common;
using Domain.Enums;
using Microsoft.Extensions.Configuration;

namespace Application.GetOtpStatus.GetOtpStatus;

public sealed class GetOtpStatusHandler(IServiceProvider serviceProvider, IUserDataService userDataService, IOtpService otpService, IConfiguration configuration) : BaseHandler<GetOtpStatusRequest, GetOtpStatusResponse>(serviceProvider)
{
    public override async Task<GetOtpStatusResponse> ExecuteAsync(GetOtpStatusRequest command, CancellationToken ct)
    {
        var user = ThrowIf.Null(await userDataService.GetActiveUserById(CurrentUserId, ct));
        if (user.EmailConfirmed)
        {
            return new GetOtpStatusResponse()
            {
                EmailConfirmationRequired = false
            };
        }
        var openOtps = await otpService.GetOpenOtps(CurrentUserId, ct);
        var options = configuration.GetOtpOptions();
        var now = DateTimeOffset.UtcNow;
        var pendingOtps = openOtps.Where(x => x.Status == OtpStatus.Pending && x.AbsoluteExpirationUtc > now).ToArray();
        if (pendingOtps.Length == 0)
        {
            return new GetOtpStatusResponse();
        }

        var lastRequestSent = pendingOtps.Max(x => x.RequestedOnUtc);
        
        return new GetOtpStatusResponse()
        {
            OtpPending = true,
            CanRequestNewOtpAtUtc = lastRequestSent.AddSeconds(options.SecondsToWaitForNewRequest)
        };
    }
}
