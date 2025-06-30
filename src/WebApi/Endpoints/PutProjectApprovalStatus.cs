using Application.PutProjectApprovalStatus.PutProjectApprovalStatus;
using WebApi.Attributes;

namespace WebApi.Endpoints;

[HttpPost(Constants.Routes.PutProjectApprovalStatus)]
public sealed class PutProjectApprovalStatus : JsonResponseEndpoint<PutProjectApprovalStatusRequest, PutProjectApprovalStatusResponse>;