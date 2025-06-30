using Application.PostRequestOtp.PostRequestOtp;
using Application.Example.GetExample;
using WebApi.Attributes;

namespace WebApi.Endpoints;

[HttpPost(Constants.Routes.PostRequestOtp)]
public sealed class PostRequestOtp : JsonResponseEndpoint<PostRequestOtpRequest, PostRequestOtpResponse>;