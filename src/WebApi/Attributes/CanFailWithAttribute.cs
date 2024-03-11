using System.Net;

namespace WebApi.Attributes;

public class CanFailWithAttribute(params HttpStatusCode[] statusCodes) : Attribute
{
    public HttpStatusCode[] StatusCodes { get; } = statusCodes;
}
