using Application.GetInternalProject.GetInternalProject;
using WebApi.Attributes;
using WebApi.Attributes.Authorization;
using WebApi.Common;

namespace WebApi.Endpoints;

[HttpGet(Constants.Routes.GetInternalProject)]
[Allow(AuthorizationObject.Anonymous)]
public class GetInternalProject : JsonResponseEndpoint<GetInternalProjectRequest, GetInternalProjectResponse>;