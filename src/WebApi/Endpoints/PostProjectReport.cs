using Application.PostProjectReport.PostProjectReport;
using WebApi.Attributes;
using WebApi.Attributes.Authorization;
using WebApi.Common;

namespace WebApi.Endpoints;

[HttpPost(Constants.Routes.PostProjectReport)]
[Allow(AuthorizationObject.AuthenticatedWithConfirmedEmail)]
public sealed class PostProjectReport : JsonResponseEndpoint<PostProjectReportRequest, PostProjectReportResponse>;