using Application.PostProject.PostProject;
using Application.Example.GetExample;
using WebApi.Attributes;

namespace WebApi.Endpoints;

[HttpPost(Constants.Routes.PostProject)]
public class PostProject : JsonResponseEndpoint<PostProjectRequest, PostProjectResponse>;