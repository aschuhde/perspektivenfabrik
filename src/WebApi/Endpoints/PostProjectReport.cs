using Application.PostProjectReport.PostProjectReport;
using WebApi.Attributes;

namespace WebApi.Endpoints;

[HttpPost(Constants.Routes.PostProjectReport)]
public sealed class PostProjectReport : JsonResponseEndpoint<PostProjectReportRequest, PostProjectReportResponse>;