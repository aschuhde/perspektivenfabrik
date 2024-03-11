using System.Net;

namespace WebApi.Attributes;

public class ResultWithAttribute(HttpStatusCode statusCode) : Attribute
{
    public HttpStatusCode StatusCode { get; } = statusCode;
}
