using System.Net;
using System.Text.Json.Serialization;

namespace Application.Common.Response;

public class BaseResponse
{
    [JsonIgnore] public HttpStatusCode StatusCode { get; init; } = HttpStatusCode.OK;
    [JsonIgnore] public bool Success => Error == null;
    [JsonIgnore] public ErrorResponseData? Error { get; init; } = null;
    [JsonIgnore] private readonly List<(string Key, string Value)> _headers = [];

    public void SetHeader(string key, string value)
    {
        _headers.Add((key, value));
    }

    public void ApplyHeaders(Action<string, string> onSetHeader)
    {
        foreach (var header in _headers)
        {
            onSetHeader(header.Key, header.Value);
        }
    }
}

public static class BaseResponseExtensions
{
    public static T WithHeader<T>(this T response, string key, string value) where T : BaseResponse
    {
        response.SetHeader(key, value);
        return response;
    }
}
