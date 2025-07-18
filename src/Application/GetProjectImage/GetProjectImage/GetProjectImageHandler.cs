using Application.Common;
using Application.Common.Response;
using Application.Services;

namespace Application.GetProjectImage.GetProjectImage;

public class GetProjectImageHandler(IServiceProvider serviceProvider, IProjectService projectService) : BaseHandler<GetProjectImageRequest, GetProjectImageResponse>(serviceProvider)
{
    public override async Task<GetProjectImageResponse> ExecuteAsync(GetProjectImageRequest command, CancellationToken ct)
    {
        var projectId = Guid.Parse(command.ProjectIdentifier);
        var imageId = Guid.Parse(command.ImageIdentifier);
        var content = await projectService.GetProjectImage(projectId, imageId, command.OnlyThumbnail, ct);
        
        if (content == null)
        {
            return new GetProjectImageNotFoundResponse();
        }
        
        return new GetProjectImageOkResponse()
        {
            ContentType = content.MimeType ?? "image/jpeg",
            Content = content.Content,
            FileName = imageId + "." + (content.FileExtension.TrimStart('.') ?? "jpg"),
            IsInline = true
        }.WithHeader("Cache-Control", "public,max-age=31536000,immutable");
    }
}
