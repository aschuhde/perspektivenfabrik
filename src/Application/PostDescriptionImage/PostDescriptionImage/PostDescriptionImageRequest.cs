using Application.Common;
using Domain.DataTypes;

namespace Application.PostDescriptionImage.PostDescriptionImage;

public class PostDescriptionImageRequest : BaseRequest<PostDescriptionImageResponse>
{
    public string ProjectIdentifier { get; init; } = "";
    public required GraphicsContent Image { get; init; }
}

