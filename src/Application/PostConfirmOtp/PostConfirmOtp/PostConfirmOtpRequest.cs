using Application.Common;

namespace Application.PostConfirmOtp.PostConfirmOtp;

public sealed class PostConfirmOtpRequest : BaseRequest<PostConfirmOtpResponse>
{
    public required PostConfirmOtpRequestBody Data { get; init; }
}

public sealed class PostConfirmOtpRequestBody
{
    public required string? Otp { get; init; }
}
