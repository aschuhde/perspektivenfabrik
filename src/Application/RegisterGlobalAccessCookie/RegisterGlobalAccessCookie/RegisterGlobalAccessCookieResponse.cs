using System.Net;
using Application.Common.Response;
using Application.Messages;

namespace Application.RegisterGlobalAccessCookie.RegisterGlobalAccessCookie;

public class RegisterGlobalAccessCookieResponse : JsonResponse
{
    
}

public class RegisterGlobalAccessCookieResponseInvalidToken : RegisterGlobalAccessCookieResponse
{
    public RegisterGlobalAccessCookieResponseInvalidToken()
    {
        Error = new ErrorResponseData() { Message = UserMessages.GlobalAccessCookieResponseInvalidToken() };
        StatusCode = HttpStatusCode.Unauthorized;
    }
}

public class RegisterGlobalAccessCookieResponseEmptyToken : RegisterGlobalAccessCookieResponse
{
    public RegisterGlobalAccessCookieResponseEmptyToken()
    {
        Error = new ErrorResponseData() { Message = UserMessages.GlobalAccessCookieResponseEmptyToken() };
        StatusCode = HttpStatusCode.BadRequest;
    }
}

public class RegisterGlobalAccessCookieSuccessResponse : RegisterGlobalAccessCookieResponse
{
    public RegisterGlobalAccessCookieSuccessResponse()
    {
        
    }
}

