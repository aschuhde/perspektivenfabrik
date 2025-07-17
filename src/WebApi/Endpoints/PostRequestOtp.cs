using Application.PostRequestOtp.PostRequestOtp;
using Application.Example.GetExample;
using WebApi.Attributes;
using WebApi.Attributes.Authorization;
using WebApi.Common;

namespace WebApi.Endpoints;

[HttpPost(Constants.Routes.PostRequestOtp)]
[Allow(AuthorizationObject.AuthenticatedWithUnconfirmedEmail)]
public sealed class PostRequestOtp : JsonResponseEndpoint<PostRequestOtpRequest, PostRequestOtpResponse>;
