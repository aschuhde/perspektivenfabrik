using System.Net;
using Application.Common.Response;

namespace Application.GetProjectImage.GetProjectImage;

public class GetProjectImageResponse : FileBytesResponse
{
    
}

public class GetProjectImageOkResponse : GetProjectImageResponse
{
    
}

public class GetProjectImageNotFoundResponse : GetProjectImageResponse
{
    public GetProjectImageNotFoundResponse()
    {
        StatusCode = HttpStatusCode.NotFound;
    }
}

