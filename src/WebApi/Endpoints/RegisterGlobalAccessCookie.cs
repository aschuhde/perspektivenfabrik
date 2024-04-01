using Application.RegisterGlobalAccessCookie.RegisterGlobalAccessCookie;
using Application.Example.GetExample;
using WebApi.Attributes;
using WebApi.Attributes.Authorization;
using WebApi.Common;

namespace WebApi.Endpoints;

[HttpGet(Constants.Routes.RegisterGlobalAccessCookie)]
[Allow(AuthorizationObject.Anonymous)]
public class RegisterGlobalAccessCookie : JsonResponseEndpoint<RegisterGlobalAccessCookieRequest, RegisterGlobalAccessCookieResponse>;