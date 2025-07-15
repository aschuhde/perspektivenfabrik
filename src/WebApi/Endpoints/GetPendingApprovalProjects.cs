using Application.GetPendingApprovalProjects.GetPendingApprovalProjects;
using WebApi.Attributes;
using WebApi.Attributes.Authorization;
using WebApi.Common;

namespace WebApi.Endpoints;

[HttpGet(Constants.Routes.GetPendingApprovalProjects)]
[Allow(AuthorizationObject.AuthenticatedWithConfirmedEmail)]
public sealed class GetPendingApprovalProjects : JsonResponseEndpoint<GetPendingApprovalProjectsRequest, GetPendingApprovalProjectsResponse>;