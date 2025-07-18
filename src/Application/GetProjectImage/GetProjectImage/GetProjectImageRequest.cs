using Application.Common;
using FastEndpoints;

namespace Application.GetProjectImage.GetProjectImage;

public class GetProjectImageRequest : BaseRequest<GetProjectImageResponse>
{
    public required string ProjectIdentifier { get; init; }
    public required string ImageIdentifier { get; init; }
    
    [BindFrom("thumbnail")]
    [QueryParam]
    public required bool OnlyThumbnail { get; init; }
}

