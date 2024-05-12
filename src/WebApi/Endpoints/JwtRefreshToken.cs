using Application.JwtRefreshToken.JwtRefreshToken;
using WebApi.Attributes;
using WebApi.Attributes.Authorization;
using WebApi.Common;

namespace WebApi.Endpoints;

[HttpPost(Constants.Routes.JwtRefreshToken)]
[Allow(AuthorizationObject.Anonymous)]
public sealed class JwtRefreshToken : JsonResponseEndpoint<JwtRefreshTokenRequest, JwtRefreshTokenResponse>;