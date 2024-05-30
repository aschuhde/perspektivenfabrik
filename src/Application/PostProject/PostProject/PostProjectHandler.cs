using System.Net;
using Application.Common;
using Application.Mapping;
using Application.Services;
using FluentValidation;

namespace Application.PostProject.PostProject;

public class PostProjectHandler(IServiceProvider serviceProvider, IValidator<PostProjectRequest> validator, IProjectService projectService) : BaseHandler<PostProjectRequest, PostProjectResponse>(serviceProvider)
{
    public override async Task<PostProjectResponse> ExecuteAsync(PostProjectRequest command, CancellationToken ct)
    {
        var validationResult = await validator.ValidateAsync(command, ct);
        if (!validationResult.IsValid)
            return new PostProjectValidationFailedResponse(validationResult);
        

        var result = await projectService.CreateProject(command.Project.ToProject(), ct);
        if (!result.Success)
            return new PostProjectCreationFailedResponse(result);
        
        return new PostProjectOkResponse()
        {
            StatusCode = result.DesiredStatusCode ?? HttpStatusCode.OK,
            Project = result.Project
        };
    }
}
