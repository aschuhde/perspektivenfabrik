using System.Security.Cryptography;
using Application.Common;
using Application.Services;
using Common;

namespace Application.PostConfirmOtp.PostConfirmOtp;

public sealed class PostConfirmOtpHandler(IServiceProvider serviceProvider, IUserDataService userDataService, IOtpService otpService, INotificationService notificationService) : BaseHandler<PostConfirmOtpRequest, PostConfirmOtpResponse>(serviceProvider)
{
    public override async Task<PostConfirmOtpResponse> ExecuteAsync(PostConfirmOtpRequest command, CancellationToken ct)
    {
        var user = ThrowIf.Null(await userDataService.GetActiveUserById(CurrentUserId, ct));
        if (user.EmailConfirmed)
        {
            return new PostConfirmOtpNotRequiredResponse();
        }
        await Task.Delay(RandomNumberGenerator.GetInt32(200, 1001), ct);
        var openOtps = await otpService.GetOpenOtps(CurrentUserId, ct);
        if (openOtps.Length == 0)
        {
            return new PostConfirmOtpNotFoundResponse();
        }
        var pendingOtps = openOtps.Where(x => x.Status == Domain.Enums.OtpStatus.Pending).ToArray(); 
        var matchedOtps = pendingOtps.Where(x => x.Otp == command.Data.Otp).ToArray();
        var confirmedOtps = matchedOtps.Where(x => x.AbsoluteExpirationUtc > DateTimeOffset.UtcNow).ToArray();
        if(matchedOtps.Length == 0 && pendingOtps.Any(x => x.AbsoluteExpirationUtc > DateTimeOffset.UtcNow))
        {
            return new PostConfirmOtpWrongResponse();
        }
        if (matchedOtps.Length == 0)
        {
            return new PostConfirmOtpNotFoundResponse();
        }
        if (confirmedOtps.Length == 0)
        {
            return new PostConfirmOtpExpiredResponse();
        }
        
        await otpService.ConfirmOtp(CurrentUserId, confirmedOtps.Select(x => x.EntityId).ToArray(), ct);
        notificationService.OtpConfirmed(CurrentUserId);
        return new PostConfirmOtpConfirmedResponse();
        
    }
}
