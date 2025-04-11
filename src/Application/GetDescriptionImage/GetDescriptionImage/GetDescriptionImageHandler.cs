using Application.Common;
using Application.Services;

namespace Application.GetDescriptionImage.GetDescriptionImage;

public class GetDescriptionImageHandler(IServiceProvider serviceProvider, IProjectService projectService) : BaseHandler<GetDescriptionImageRequest, GetDescriptionImageResponse>(serviceProvider)
{
    public override async Task<GetDescriptionImageResponse> ExecuteAsync(GetDescriptionImageRequest command, CancellationToken ct)
    {
        var projectId = Guid.Parse(command.ProjectIdentifier);
        var imageId = Guid.Parse(command.ImageIdentifier);
        var image = await projectService.GetDescriptionImage(projectId, imageId, ct);
        if (image?.Content == null)
        {
            return new GetDescriptionImageNotFoundResponse();
        }
        return new GetDescriptionImageOkResponse()
        {
            ContentType = "image/jpeg",
            Content = image.Content?.Content,
            FileName = imageId.ToString() + ".jpg",
            IsInline = true
        };
    }
}
