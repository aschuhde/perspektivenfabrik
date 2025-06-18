using Application.Common;
using Application.Filter;
using Application.Selectors;
using FastEndpoints;

namespace Application.GetPendingApprovalProjects.GetPendingApprovalProjects;

public sealed class GetPendingApprovalProjectsRequest : BaseRequest<GetPendingApprovalProjectsResponse>
{
    [BindFrom("with-rejected-and-approved")]
    [QueryParam]
    public bool IncludeRejectedAndApproved { get; init; }
    public ProjectFilter? Filter { get; init; }
    public ProjectSelector? Selector { get; init; }
}

