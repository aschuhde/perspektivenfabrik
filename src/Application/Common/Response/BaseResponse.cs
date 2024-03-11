using System.Net;
using System.Text.Json.Serialization;

namespace Application.Common.Response;

public class BaseResponse
{
    [JsonIgnore] public HttpStatusCode StatusCode { get; init; } = HttpStatusCode.OK;
    [JsonIgnore] public bool Success => Error == null;
    [JsonIgnore] public ErrorResponseData? Error { get; init; } = null;
}
