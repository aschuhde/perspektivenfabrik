using System.Net;
using Application.Common.Response;
using Application.Messages;

namespace Application.NotFound;

public sealed class NotFoundResponse : JsonResponse
{
    public NotFoundResponse()
    {
        Error = new ErrorResponseData() { Message = UserMessages.UrlNotFound() };
        StatusCode = HttpStatusCode.NotFound;
    }
}
