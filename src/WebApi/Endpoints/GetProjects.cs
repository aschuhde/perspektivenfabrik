using Application.GetProjects.GetProjects;
using Application.Example.GetExample;
using WebApi.Attributes;

namespace WebApi.Endpoints;

[HttpGet(Constants.Routes.GetProjects)]
public class GetProjects : JsonResponseEndpoint<GetProjectsRequest, GetProjectsResponse>;