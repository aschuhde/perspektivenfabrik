using System.Net;

namespace WebApi.Attributes;

public sealed class ResultWithAttribute(HttpStatusCode statusCode) : Attribute
{
    public HttpStatusCode StatusCode { get; } = statusCode;
}
