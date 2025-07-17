using System.Net;
using System.Text.Json.Serialization;
using Application.Common.Response;
using Application.Messages;

namespace Application.PostConfirmOtp.PostConfirmOtp;

public class PostConfirmOtpResponse : JsonResponse
{
    public OtpStatus Status { get; init; }
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum OtpStatus
{
    Confirmed,
    Expired,
    Wrong,
    NotRequired,
}

public sealed class PostConfirmOtpExpiredResponse : PostConfirmOtpResponse
{
    public PostConfirmOtpExpiredResponse()
    {
        StatusCode = HttpStatusCode.OK;
        Status = OtpStatus.Expired;
    }
}

public sealed class PostConfirmOtpWrongResponse : PostConfirmOtpResponse
{
    public PostConfirmOtpWrongResponse()
    {
        StatusCode = HttpStatusCode.OK;
        Status = OtpStatus.Wrong;
    }
}

public sealed class PostConfirmOtpNotFoundResponse : PostConfirmOtpResponse
{
    public PostConfirmOtpNotFoundResponse()
    {
        StatusCode = HttpStatusCode.NotFound;
        Status = OtpStatus.Wrong;
        Error = new ErrorResponseData() { Message = OtpMessages.NotFound() };
    }
}

public sealed class PostConfirmOtpNotRequiredResponse : PostConfirmOtpResponse
{
    public PostConfirmOtpNotRequiredResponse()
    {
        StatusCode = HttpStatusCode.MethodNotAllowed;
        Status = OtpStatus.NotRequired;
        Error = new ErrorResponseData() { Message = OtpMessages.NotRequired() };
    }
}

public sealed class PostConfirmOtpConfirmedResponse : PostConfirmOtpResponse
{
    public PostConfirmOtpConfirmedResponse()
    {
        StatusCode = HttpStatusCode.OK;
        Status = OtpStatus.Confirmed;
    }
}

