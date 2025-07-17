using Application.PostConfirmOtp.PostConfirmOtp;
using Application.Example.GetExample;
using WebApi.Attributes;
using WebApi.Attributes.Authorization;
using WebApi.Common;

namespace WebApi.Endpoints;

[HttpPost(Constants.Routes.PostConfirmOtp)]
[Allow(AuthorizationObject.AuthenticatedWithUnconfirmedEmail)]
public sealed class PostConfirmOtp : JsonResponseEndpoint<PostConfirmOtpRequest, PostConfirmOtpResponse>;
