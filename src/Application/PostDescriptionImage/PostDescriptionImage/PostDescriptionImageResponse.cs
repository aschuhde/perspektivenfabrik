using System.Net;
using Application.Common.Response;

namespace Application.PostDescriptionImage.PostDescriptionImage;

public class PostDescriptionImageResponse : JsonResponse
{
    public string? ImageIdentifier { get; init; }
}
public class PostDescriptionNotFoundResponse : PostDescriptionImageResponse
{
    public PostDescriptionNotFoundResponse()
    {
        StatusCode = HttpStatusCode.NotFound;
    }
}
public class PostDescriptionForbiddenResponse : PostDescriptionImageResponse
{
    public PostDescriptionForbiddenResponse()
    {
        StatusCode = HttpStatusCode.Forbidden;
    }
}
