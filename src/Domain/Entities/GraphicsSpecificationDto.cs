using Domain.DataTypes;
using Domain.Enums;

namespace Domain.Entities;

public sealed class GraphicsSpecificationDto : BaseEntityDto
{
    public required GraphicsType Type { get; init; }
    public required GraphicsContent Content { get; init; }
}