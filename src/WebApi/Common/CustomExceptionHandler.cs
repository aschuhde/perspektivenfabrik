using System.Net;
using System.Text.Json;
using Application.Common.Response;
using Microsoft.AspNetCore.Diagnostics;

namespace WebApi.Common;

public class CustomExceptionHandler(ILogger<CustomExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var errorId = Guid.NewGuid();
        logger.LogError(exception, "An internal server error occurred with id {ErrorId}.", errorId);

        var error = new ErrorResponse
        {
            Error = new ErrorResponseData
            {
                Message = "An internal server error occurred.",
                ErrorId = errorId
            },
            HttpVerb = httpContext.Request.Method,
            RequestedUrl = httpContext.Request.GetUri().ToString()
        };
        httpContext.Response.ContentType = "application/json; charset=utf-8";
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        await httpContext.Response.WriteAsync(error.ToJson(), cancellationToken);
        return true;
    }
}