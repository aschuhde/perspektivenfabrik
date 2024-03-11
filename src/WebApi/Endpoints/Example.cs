using Application.Example.GetExample;
using WebApi.Attributes;

namespace WebApi.Endpoints;

[HttpGet(Constants.Routes.Example)]
public class GetExample : JsonResponseEndpoint<GetExampleRequest, GetExampleResponse>;
