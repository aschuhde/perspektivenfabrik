using Application.Common;
using Application.Services;

namespace Application.PostDescriptionImage.PostDescriptionImage;

public class PostDescriptionImageHandler(IServiceProvider serviceProvider, IProjectService projectService, ICurrentUserService currentUserService) : BaseHandler<PostDescriptionImageRequest, PostDescriptionImageResponse>(serviceProvider)
{
    public override async Task<PostDescriptionImageResponse> ExecuteAsync(PostDescriptionImageRequest command, CancellationToken ct)
    {
        var projectId = Guid.Parse(command.ProjectIdentifier);

        if (!await CanAccessProject(projectId, ct))
        {
            return new PostDescriptionForbiddenResponse();
        }

        if (!await projectService.ProjectExists(projectId, ct))
        {
            return new PostDescriptionNotFoundResponse();
        }

        var imageId = await projectService.AddDescriptionImage(projectId, command.Image.Content, ct);
        return new PostDescriptionImageResponse()
        {
            ImageIdentifier = imageId.ToString()
        };
    }

    private async Task<bool> CanAccessProject(Guid projectId, CancellationToken ct)
    {
        if (currentUserService.IsAdmin) return true;
        var userId = currentUserService.CurrentUserId;
        return userId == await projectService.GetOwnerId(projectId, ct) 
               || ((await projectService.GetContributorIds(projectId, ct))?.Contains(userId) ?? false);
    }
}
