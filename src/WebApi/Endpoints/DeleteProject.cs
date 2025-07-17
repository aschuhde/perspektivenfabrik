using Application.DeleteProject.DeleteProject;
using WebApi.Attributes;
using WebApi.Attributes.Authorization;
using WebApi.Common;

namespace WebApi.Endpoints;

[HttpDelete(Constants.Routes.DeleteProject)]
[Allow(AuthorizationObject.AuthenticatedWithConfirmedEmail)]
public class DeleteProject : JsonResponseEndpoint<DeleteProjectRequest, DeleteProjectResponse>;