using Application.PostProject.PostProject;
using WebApi.Attributes;

namespace WebApi.Endpoints;

[HttpPost(Constants.Routes.PostProject)]
public class PostProject : JsonResponseEndpoint<PostProjectRequest, PostProjectResponse>;