using Domain.DataTypes;

namespace Domain.Entities;

public sealed class DescriptionImageDto : BaseEntityWithIdDto
{
    public required Guid ProjectId { get; init; }
    public required GraphicsContent Content { get; init; }
}