using Application.Common;
using Application.Mapping;
using Application.Services;

namespace Application.GetUsersProjects.GetUsersProjects;

public class GetUsersProjectsHandler(IServiceProvider serviceProvider, IProjectService projectService) : BaseHandler<GetUsersProjectsRequest, GetUsersProjectsResponse>(serviceProvider)
{
    public override async Task<GetUsersProjectsResponse> ExecuteAsync(GetUsersProjectsRequest command, CancellationToken ct)
    {
        return new GetUsersProjectsResponse()
        {
            Projects = (await projectService.GetUsersProjects(command.Filter, command.Selector, ct)).Select(x => x.ToApiProject()).ToArray()
        };
    }
}
