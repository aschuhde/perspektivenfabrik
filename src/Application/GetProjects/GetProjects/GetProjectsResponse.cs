using Application.Common.Response;
using Application.Models.ApiModels;

namespace Application.GetProjects.GetProjects;

public class GetProjectsResponse : JsonResponse
{
    public required ApiProject[] Projects { get; init; }
}

