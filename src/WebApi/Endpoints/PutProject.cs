using Application.PutProject.PutProject;
using WebApi.Attributes;

namespace WebApi.Endpoints;

[HttpPut(Constants.Routes.PutProject)]
public sealed class PutProject : JsonResponseEndpoint<PutProjectRequest, PutProjectResponse>;