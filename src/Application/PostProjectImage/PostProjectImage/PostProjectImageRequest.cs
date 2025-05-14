using Application.Common;
using Domain.DataTypes;

namespace Application.PostProjectImage.PostProjectImage;

public class PostProjectImageRequest : BaseRequest<PostProjectImageResponse>
{
    public string ProjectIdentifier { get; init; } = "";
    public required GraphicsContent Image { get; init; }
}

