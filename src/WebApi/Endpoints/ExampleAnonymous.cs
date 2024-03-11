using Application.ExampleAnonymous.GetExampleAnonymous;
using WebApi.Attributes;
using WebApi.Attributes.Authorization;
using WebApi.Common;

namespace WebApi.Endpoints;

[HttpGet(Constants.Routes.GetExampleAnonymous)]
[Allow(AuthorizationObject.Anonymous)]
public class GetExampleAnonymous : JsonResponseEndpoint<GetExampleAnonymousRequest, GetExampleAnonymousResponse>;