using Application.GetPendingApprovalProjects.GetPendingApprovalProjects;
using WebApi.Attributes;

namespace WebApi.Endpoints;

[HttpGet(Constants.Routes.GetPendingApprovalProjects)]
public sealed class GetPendingApprovalProjects : JsonResponseEndpoint<GetPendingApprovalProjectsRequest, GetPendingApprovalProjectsResponse>;