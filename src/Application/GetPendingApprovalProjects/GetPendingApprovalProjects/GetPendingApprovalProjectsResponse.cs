using System.Net;
using Application.Common.Response;
using Application.Models.ApiModels;
using Common;

namespace Application.GetPendingApprovalProjects.GetPendingApprovalProjects;

public class GetPendingApprovalProjectsResponse : JsonResponse
{
    
}

public sealed class GetPendingApprovalProjectsNotAllowedResponse : GetPendingApprovalProjectsResponse
{
    public GetPendingApprovalProjectsNotAllowedResponse(Message reason)
    {
        StatusCode = HttpStatusCode.Forbidden;
        Error = new ErrorResponseData { Message = reason };
    }
}

public sealed class GetPendingApprovalProjectsOkResponse : GetPendingApprovalProjectsResponse
{
    public required ApiProject[] Projects { get; init; }
}

