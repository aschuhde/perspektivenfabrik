using Domain.DataTypes;

namespace Domain.Entities;

public sealed class ProjectImageDto : BaseEntityWithIdDto
{
    public required Guid ProjectId { get; init; }
    public required GraphicsContent Content { get; init; }
    public required GraphicsContent? Thumbnail { get; init; }
}