using Application.Common;
using Application.Mapping;
using Application.Services;

namespace Application.GetProjects.GetProjects;

public class GetProjectsHandler(IServiceProvider serviceProvider, IProjectService projectService) : BaseHandler<GetProjectsRequest, GetProjectsResponse>(serviceProvider)
{
    public override async Task<GetProjectsResponse> ExecuteAsync(GetProjectsRequest command, CancellationToken ct)
    {
        return new GetProjectsResponse()
        {
            Projects = (await projectService.GetPublicProjects(command.Filter, command.Selector, ct)).Select(x => x.ToApiProject()).ToArray()
        };
    }
}
