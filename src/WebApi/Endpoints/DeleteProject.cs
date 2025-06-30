using Application.DeleteProject.DeleteProject;
using WebApi.Attributes;

namespace WebApi.Endpoints;

[HttpDelete(Constants.Routes.DeleteProject)]
public class DeleteProject : JsonResponseEndpoint<DeleteProjectRequest, DeleteProjectResponse>;