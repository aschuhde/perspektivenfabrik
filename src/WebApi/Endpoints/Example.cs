using Application.Example.GetExample;
using WebApi.Attributes;

namespace WebApi.Endpoints;

[HttpGet(Constants.Routes.Example)]
public sealed class GetExample : JsonResponseEndpoint<GetExampleRequest, GetExampleResponse>;
