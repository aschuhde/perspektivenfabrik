using System.Net;
using Application.Common.Response;
using Common;

namespace Application.PutProjectApprovalStatus.PutProjectApprovalStatus;

public class PutProjectApprovalStatusResponse : JsonResponse
{
    
}

public sealed class PutProjectApprovalStatusNotAllowedResponse : PutProjectApprovalStatusResponse
{
    public PutProjectApprovalStatusNotAllowedResponse(Message reason)
    {
        StatusCode = HttpStatusCode.Forbidden;
        Error = new ErrorResponseData() { Message = reason };
    }
}
public sealed class PutProjectApprovalStatusNotFoundResponse : PutProjectApprovalStatusResponse
{
    public PutProjectApprovalStatusNotFoundResponse(Message reason)
    {
        StatusCode = HttpStatusCode.NotFound;
        Error = new ErrorResponseData() { Message = reason };
    }
}
public sealed class PutProjectApprovalStatusOk : PutProjectApprovalStatusResponse
{
    public PutProjectApprovalStatusOk()
    {
        StatusCode = HttpStatusCode.OK;
    }
}

public sealed class PutProjectApprovalStatusAlreadyApproved : PutProjectApprovalStatusResponse
{
    public bool AlreadyApproved => true;
    public PutProjectApprovalStatusAlreadyApproved()
    {
        StatusCode = HttpStatusCode.OK;
    }
}