using Application.Common;
using Application.Services;

namespace Application.PostProjectImage.PostProjectImage;

public class PostProjectImageHandler(IServiceProvider serviceProvider, IProjectService projectService, ICurrentUserService currentUserService, IImageService imageService) : BaseHandler<PostProjectImageRequest, PostProjectImageResponse>(serviceProvider)
{
    private const uint MaxImageWidth = 1920;
    public override async Task<PostProjectImageResponse> ExecuteAsync(PostProjectImageRequest command, CancellationToken ct)
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

        var imageId = await projectService.AddProjectImage(projectId, imageService.ResizeImageIfExceedsThreshold(command.Image.Content, MaxImageWidth), ct);
        return new PostProjectImageResponse()
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
