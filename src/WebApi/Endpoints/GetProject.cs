using Application.GetProject.GetProject;
using WebApi.Attributes;
using WebApi.Attributes.Authorization;
using WebApi.Common;

namespace WebApi.Endpoints;

[HttpGet(Constants.Routes.GetProject)]
[Allow(AuthorizationObject.Anonymous)]
public class GetProject : JsonResponseEndpoint<GetProjectRequest, GetProjectResponse>;