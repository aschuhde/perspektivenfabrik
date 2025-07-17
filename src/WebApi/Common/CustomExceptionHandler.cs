using System.Net;
using System.Text.Json;
using Application.Common;
using Application.Common.Response;
using Application.Services;
using Microsoft.AspNetCore.Diagnostics;

namespace WebApi.Common;

public class CustomExceptionHandler(ILogger<CustomExceptionHandler> logger, INotificationService? notificationService = null) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var errorId = Guid.NewGuid();
        logger.LogError(exception, "An internal server error occurred with id {ErrorId}.", errorId);
        var requestUrl = httpContext.Request.GetUri().ToString();
        notificationService?.ErrorOccured(errorId, exception.ToString(), httpContext.Request.Method, requestUrl, httpContext.User.GetUserIdOrNull());
        var error = new ErrorResponse
        {
            Error = new ErrorResponseData
            {
                Message = "An internal server error occurred.",
                ErrorId = errorId
            },
            HttpVerb = httpContext.Request.Method,
            RequestedUrl = requestUrl
        };
        httpContext.Response.ContentType = "application/json; charset=utf-8";
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        await httpContext.Response.WriteAsync(error.ToJson(), cancellationToken);
        
        return true;
    }
}