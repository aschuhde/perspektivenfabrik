using Application.GetUsersProjects.GetUsersProjects;
using WebApi.Attributes;
using WebApi.Attributes.Authorization;
using WebApi.Common;

namespace WebApi.Endpoints;

[HttpGet(Constants.Routes.GetUsersProjects)]
[Allow(AuthorizationObject.AuthenticatedWithConfirmedEmail)]
public class GetUsersProjects : JsonResponseEndpoint<GetUsersProjectsRequest, GetUsersProjectsResponse>;