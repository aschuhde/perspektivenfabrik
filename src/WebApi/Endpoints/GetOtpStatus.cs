using Application.GetOtpStatus.GetOtpStatus;
using Application.Example.GetExample;
using WebApi.Attributes;
using WebApi.Attributes.Authorization;
using WebApi.Common;

namespace WebApi.Endpoints;

[HttpGet(Constants.Routes.GetOtpStatus)]
[Allow(AuthorizationObject.AuthenticatedWithUnconfirmedEmail)]
public sealed class GetOtpStatus : JsonResponseEndpoint<GetOtpStatusRequest, GetOtpStatusResponse>;