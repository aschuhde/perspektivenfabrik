using Application.Common;

namespace Application.GetDescriptionImage.GetDescriptionImage;

public class GetDescriptionImageRequest : BaseRequest<GetDescriptionImageResponse>
{
    public required string ProjectIdentifier { get; init; }
    public required string ImageIdentifier { get; init; }
}

