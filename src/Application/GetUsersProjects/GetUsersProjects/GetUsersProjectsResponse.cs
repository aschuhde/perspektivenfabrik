using Application.Common.Response;
using Application.Models.ApiModels;

namespace Application.GetUsersProjects.GetUsersProjects;

public class GetUsersProjectsResponse : JsonResponse
{
    public required ApiProject[] Projects { get; init; }
}

