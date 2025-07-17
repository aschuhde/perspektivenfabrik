using Application.PostProject.PostProject;
using WebApi.Attributes;
using WebApi.Attributes.Authorization;
using WebApi.Common;

namespace WebApi.Endpoints;

[HttpPost(Constants.Routes.PostProject)]
[Allow(AuthorizationObject.AuthenticatedWithConfirmedEmail)]
public class PostProject : JsonResponseEndpoint<PostProjectRequest, PostProjectResponse>;