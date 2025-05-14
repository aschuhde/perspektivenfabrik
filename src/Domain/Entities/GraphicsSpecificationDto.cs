using Domain.DataTypes;
using Domain.Enums;

namespace Domain.Entities;

public sealed class GraphicsSpecificationDto : BaseEntityWithIdDto
{
    public required GraphicsType Type { get; init; }
    public required Guid ImageId { get; init; }
}