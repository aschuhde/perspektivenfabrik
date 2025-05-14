using System.Net;
using Application.Common.Response;

namespace Application.PostProjectImage.PostProjectImage;

public class PostProjectImageResponse : JsonResponse
{
    public string? ImageIdentifier { get; init; }
}
public class PostDescriptionNotFoundResponse : PostProjectImageResponse
{
    public PostDescriptionNotFoundResponse()
    {
        StatusCode = HttpStatusCode.NotFound;
    }
}
public class PostDescriptionForbiddenResponse : PostProjectImageResponse
{
    public PostDescriptionForbiddenResponse()
    {
        StatusCode = HttpStatusCode.Forbidden;
    }
}
