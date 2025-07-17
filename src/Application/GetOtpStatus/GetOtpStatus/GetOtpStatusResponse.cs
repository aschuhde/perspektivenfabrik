using Application.Common.Response;

namespace Application.GetOtpStatus.GetOtpStatus;

public sealed class GetOtpStatusResponse : JsonResponse
{
    public bool EmailConfirmationRequired { get; set; } = true;
    public bool OtpPending { get; set; }
    public DateTimeOffset? CanRequestNewOtpAtUtc { get; set; }
}

