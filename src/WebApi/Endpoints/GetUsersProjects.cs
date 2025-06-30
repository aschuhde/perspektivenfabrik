using Application.GetUsersProjects.GetUsersProjects;
using WebApi.Attributes;

namespace WebApi.Endpoints;

[HttpGet(Constants.Routes.GetUsersProjects)]
public class GetUsersProjects : JsonResponseEndpoint<GetUsersProjectsRequest, GetUsersProjectsResponse>;