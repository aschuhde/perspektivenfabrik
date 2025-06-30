using Application.Common;

namespace Application.PostProjectReport.PostProjectReport;

public sealed class PostProjectReportRequest : BaseRequest<PostProjectReportResponse>
{
    public Guid EntityId { get; init; } = Guid.Empty;
    
    public required PostProjectReportRequestBody Data { get; init; }
}

public sealed class PostProjectReportRequestBody
{
    public required string? Reason { get; init; }
        
}