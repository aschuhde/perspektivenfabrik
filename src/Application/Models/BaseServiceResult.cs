using System.Net;
using Application.Common.Response;

namespace Application.Models;

public class BaseServiceResult
{
    public required bool Success { get; init; }
    public required HttpStatusCode? DesiredStatusCode { get; init; } 
    public abstract ErrorResponseData ToErrorResponseData();
}