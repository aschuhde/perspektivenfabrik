using Application.GetUsersProject.GetUsersProject;
using WebApi.Attributes;
using WebApi.Attributes.Authorization;
using WebApi.Common;

namespace WebApi.Endpoints;

[HttpGet(Constants.Routes.GetUsersProject)]
[Allow(AuthorizationObject.AuthenticatedWithConfirmedEmail)]
public class GetUsersProject : JsonResponseEndpoint<GetUsersProjectRequest, GetUsersProjectResponse>;