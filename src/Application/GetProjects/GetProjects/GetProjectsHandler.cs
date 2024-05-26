using Application.Common;

namespace Application.GetProjects.GetProjects;

public class GetProjectsHandler(IServiceProvider serviceProvider) : BaseHandler<GetProjectsRequest, GetProjectsResponse>(serviceProvider)
{
    public override Task<GetProjectsResponse> ExecuteAsync(GetProjectsRequest command, CancellationToken ct)
    {
        return Task.FromResult(new GetProjectsResponse() { });
    }
}
