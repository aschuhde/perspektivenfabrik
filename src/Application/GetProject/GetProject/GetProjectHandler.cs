using Application.Common;
using Application.Mapping;
using Application.Services;

namespace Application.GetProject.GetProject;

public class GetProjectHandler(IServiceProvider serviceProvider, IProjectService projectService) : BaseHandler<GetProjectRequest, GetProjectResponse>(serviceProvider)
{
    public override async Task<GetProjectResponse> ExecuteAsync(GetProjectRequest command, CancellationToken ct)
    {
        var projectDto = await projectService.GetProjectById(Guid.Parse(command.ProjectIdentifier), ct);
        var project = projectDto?.ToApiProject();
        if (project == null)
        {
            return new GetProjectResponseNotFound();
        }
        return new GetProjectResponseSuccess()
        {
            Project = project
        };
    }
}
