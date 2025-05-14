using Application.Common;
using Application.Services;

namespace Application.GetProjectImage.GetProjectImage;

public class GetProjectImageHandler(IServiceProvider serviceProvider, IProjectService projectService) : BaseHandler<GetProjectImageRequest, GetProjectImageResponse>(serviceProvider)
{
    public override async Task<GetProjectImageResponse> ExecuteAsync(GetProjectImageRequest command, CancellationToken ct)
    {
        var projectId = Guid.Parse(command.ProjectIdentifier);
        var imageId = Guid.Parse(command.ImageIdentifier);
        var image = await projectService.GetProjectImage(projectId, imageId, ct);
        if (image?.Content == null)
        {
            return new GetProjectImageNotFoundResponse();
        }
        return new GetProjectImageOkResponse()
        {
            ContentType = "image/jpeg",
            Content = image.Content?.Content,
            FileName = imageId.ToString() + ".jpg",
            IsInline = true
        };
    }
}
