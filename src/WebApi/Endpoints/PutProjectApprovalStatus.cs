using Application.PutProjectApprovalStatus.PutProjectApprovalStatus;
using WebApi.Attributes;
using WebApi.Attributes.Authorization;
using WebApi.Common;

namespace WebApi.Endpoints;

[HttpPost(Constants.Routes.PutProjectApprovalStatus)]
[Allow(AuthorizationObject.AuthenticatedWithConfirmedEmail)]
public sealed class PutProjectApprovalStatus : JsonResponseEndpoint<PutProjectApprovalStatusRequest, PutProjectApprovalStatusResponse>;