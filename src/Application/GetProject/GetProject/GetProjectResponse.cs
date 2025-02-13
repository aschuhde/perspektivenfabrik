using System.Net;
using Application.Common.Response;
using Application.Models.ApiModels;

namespace Application.GetProject.GetProject;

public class GetProjectResponse : JsonResponse
{
    
}

public class GetProjectResponseNotFound : GetProjectResponse
{
    public GetProjectResponseNotFound()
    {
        StatusCode = HttpStatusCode.NotFound;
    }
}

public class GetProjectResponseSuccess : GetProjectResponse
{
    public required ApiProject Project { get; init; }
}


