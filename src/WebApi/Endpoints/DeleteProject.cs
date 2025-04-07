using Application.DeleteProject.DeleteProject;
using Application.Example.GetExample;
using WebApi.Attributes;

namespace WebApi.Endpoints;

[HttpDelete(Constants.Routes.DeleteProject)]
public class DeleteProject : JsonResponseEndpoint<DeleteProjectRequest, DeleteProjectResponse>;