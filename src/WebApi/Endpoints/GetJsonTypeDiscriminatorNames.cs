using Application.GetJsonTypeDiscriminatorNames.GetJsonTypeDiscriminatorNames;
using WebApi.Attributes;
using WebApi.Attributes.Authorization;
using WebApi.Common;

namespace WebApi.Endpoints;

[HttpGet(Constants.Routes.GetJsonTypeDiscriminatorNames)]
[Allow(AuthorizationObject.AuthenticatedWithConfirmedEmail)]
public class GetJsonTypeDiscriminatorNames : JsonResponseEndpoint<GetJsonTypeDiscriminatorNamesRequest, GetJsonTypeDiscriminatorNamesResponse>;