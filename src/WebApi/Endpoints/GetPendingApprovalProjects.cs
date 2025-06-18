using Application.GetPendingApprovalProjects.GetPendingApprovalProjects;
using Application.Example.GetExample;
using WebApi.Attributes;

namespace WebApi.Endpoints;

[HttpGet(Constants.Routes.GetPendingApprovalProjects)]
public sealed class GetPendingApprovalProjects : JsonResponseEndpoint<GetPendingApprovalProjectsRequest, GetPendingApprovalProjectsResponse>;