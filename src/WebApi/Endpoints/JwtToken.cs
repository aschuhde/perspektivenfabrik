using Application.JwtToken;
using WebApi.Attributes;
using WebApi.Attributes.Authorization;
using WebApi.Common;

namespace WebApi.Endpoints;

[HttpPost(Constants.Routes.JwtToken)]
[Allow(AuthorizationObject.Anonymous)]
public sealed class JwtToken : JsonResponseEndpoint<JwtTokenRequest, JwtTokenResponse>;
