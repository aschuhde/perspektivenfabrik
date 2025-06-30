using Application.PostConfirmOtp.PostConfirmOtp;
using Application.Example.GetExample;
using WebApi.Attributes;

namespace WebApi.Endpoints;

[HttpPost(Constants.Routes.PostConfirmOtp)]
public sealed class PostConfirmOtp : JsonResponseEndpoint<PostConfirmOtpRequest, PostConfirmOtpResponse>;