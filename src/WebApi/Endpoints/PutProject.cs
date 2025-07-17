using Application.PutProject.PutProject;
using WebApi.Attributes;
using WebApi.Attributes.Authorization;
using WebApi.Common;

namespace WebApi.Endpoints;

[HttpPut(Constants.Routes.PutProject)]
[Allow(AuthorizationObject.AuthenticatedWithConfirmedEmail)]
public sealed class PutProject : JsonResponseEndpoint<PutProjectRequest, PutProjectResponse>;