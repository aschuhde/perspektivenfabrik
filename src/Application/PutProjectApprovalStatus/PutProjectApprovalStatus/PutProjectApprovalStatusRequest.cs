using Application.Common;
using Domain.Enums;

namespace Application.PutProjectApprovalStatus.PutProjectApprovalStatus;

public sealed class PutProjectApprovalStatusRequest : BaseRequest<PutProjectApprovalStatusResponse>
{
    public Guid EntityId { get; init; } = Guid.Empty;
    
    public required PutProjectApprovalStatusRequestBody Data { get; init; }
}

public sealed class PutProjectApprovalStatusRequestBody
{
    public required ApprovalStatus ApprovalStatus { get; init; }
}

