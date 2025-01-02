using Application.PutProject.PutProject;
using Application.Example.GetExample;
using WebApi.Attributes;

namespace WebApi.Endpoints;

[HttpPut(Constants.Routes.PutProject)]
public sealed class PutProject : JsonResponseEndpoint<PutProjectRequest, PutProjectResponse>;