using Application.Common;

namespace Application.GetProjectImage.GetProjectImage;

public class GetProjectImageRequest : BaseRequest<GetProjectImageResponse>
{
    public required string ProjectIdentifier { get; init; }
    public required string ImageIdentifier { get; init; }
}

