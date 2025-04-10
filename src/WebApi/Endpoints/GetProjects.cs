using Application.GetProjects.GetProjects;
using WebApi.Attributes;
using WebApi.Attributes.Authorization;
using WebApi.Common;

namespace WebApi.Endpoints;

[HttpGet(Constants.Routes.GetProjects)]
[Allow(AuthorizationObject.Anonymous)]
public class GetProjects : JsonResponseEndpoint<GetProjectsRequest, GetProjectsResponse>;