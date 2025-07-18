using Application.Common;
using Domain.DataTypes;

namespace Application.PostProjectImage.PostProjectImage;

public class PostProjectImageRequest : BaseRequest<PostProjectImageResponse>
{
    public string ProjectIdentifier { get; init; } = "";
    public required GraphicsContentBytes Image { get; init; }
}

public class GraphicsContentBytes
{
    public required byte[] Content { get; init; }
}
