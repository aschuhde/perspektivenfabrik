using Application.GetUsersProject.GetUsersProject;
using WebApi.Attributes;

namespace WebApi.Endpoints;

[HttpGet(Constants.Routes.GetUsersProject)]
public class GetUsersProject : JsonResponseEndpoint<GetUsersProjectRequest, GetUsersProjectResponse>;