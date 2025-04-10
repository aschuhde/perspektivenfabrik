using System.Net;
using Application.Common.Response;
using Application.Models.ApiModels;

namespace Application.GetInternalProject.GetInternalProject;

public class GetInternalProjectResponse : JsonResponse
{
    
}

public class GetInternalProjectResponseNotFound : GetInternalProjectResponse
{
    public GetInternalProjectResponseNotFound()
    {
        StatusCode = HttpStatusCode.NotFound;
    }
}

public class GetInternalProjectResponseForbidden : GetInternalProjectResponse
{
    public GetInternalProjectResponseForbidden()
    {
        StatusCode = HttpStatusCode.Forbidden;
    }
}

public class GetInternalProjectResponseSuccess : GetInternalProjectResponse
{
    public required ApiProject Project { get; init; }
}
