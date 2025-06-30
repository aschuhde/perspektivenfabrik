using System.Net;
using Application.Common.Response;
using Application.Messages;

namespace Application.PostRequestOtp.PostRequestOtp;

public class PostRequestOtpResponse : JsonResponse
{
    
}

public sealed class PostRequestOtpPleaseWaitResponse : PostRequestOtpResponse
{
    public PostRequestOtpPleaseWaitResponse(int secondsToWait)
    {
        StatusCode = HttpStatusCode.MethodNotAllowed;
        Error = new ErrorResponseData() { Message = OtpMessages.PleaseWaitForNewRequest(secondsToWait) };
    }
}
public sealed class PostRequestOtpNotRequiredResponse : PostRequestOtpResponse
{
    public PostRequestOtpNotRequiredResponse()
    {
        StatusCode = HttpStatusCode.MethodNotAllowed;
        Error = new ErrorResponseData() { Message = OtpMessages.NotRequired() };
    }
}
public sealed class PostRequestOtpOkResponse : PostRequestOtpResponse
{
    
}