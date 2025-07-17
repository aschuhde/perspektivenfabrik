using Application.Example.GetExample;
using WebApi.Attributes;
using WebApi.Attributes.Authorization;
using WebApi.Common;

namespace WebApi.Endpoints;

[HttpGet(Constants.Routes.Example)]
[Allow(AuthorizationObject.AuthenticatedWithConfirmedEmail)]
public sealed class GetExample : JsonResponseEndpoint<GetExampleRequest, GetExampleResponse>;
