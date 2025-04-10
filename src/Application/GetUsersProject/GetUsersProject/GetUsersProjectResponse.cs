using System.Net;
using Application.Common.Response;
using Application.Models.ApiModels;

namespace Application.GetUsersProject.GetUsersProject;

public class GetUsersProjectResponse : JsonResponse
{
    
}

public class GetUsersProjectResponseNotFound : GetUsersProjectResponse
{
    public GetUsersProjectResponseNotFound()
    {
        StatusCode = HttpStatusCode.NotFound;
    }
}

public class GetUsersProjectResponseForbidden : GetUsersProjectResponse
{
    public GetUsersProjectResponseForbidden()
    {
        StatusCode = HttpStatusCode.Forbidden;
    }
}

public class GetUsersProjectResponseSuccess : GetUsersProjectResponse
{
    public required ApiProject Project { get; init; }
}
