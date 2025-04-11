using System.Net;
using Application.Common.Response;

namespace Application.GetDescriptionImage.GetDescriptionImage;

public class GetDescriptionImageResponse : FileBytesResponse
{
    
}

public class GetDescriptionImageOkResponse : GetDescriptionImageResponse
{
    
}

public class GetDescriptionImageNotFoundResponse : GetDescriptionImageResponse
{
    public GetDescriptionImageNotFoundResponse()
    {
        StatusCode = HttpStatusCode.NotFound;
    }
}

