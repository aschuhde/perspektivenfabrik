using Application.GetUsersProjects.GetUsersProjects;
using Application.Example.GetExample;
using WebApi.Attributes;

namespace WebApi.Endpoints;

[HttpGet(Constants.Routes.GetUsersProjects)]
public class GetUsersProjects : JsonResponseEndpoint<GetUsersProjectsRequest, GetUsersProjectsResponse>;