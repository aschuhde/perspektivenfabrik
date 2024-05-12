using System.Net;

namespace WebApi.Attributes;

public sealed class CanFailWithAttribute(params HttpStatusCode[] statusCodes) : Attribute
{
    public HttpStatusCode[] StatusCodes { get; } = statusCodes;
}
