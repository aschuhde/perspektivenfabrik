using Domain.DataTypes;

namespace Domain.Entities;

public sealed class MaterialSpecificationDto : BaseEntityDto
{
    public required string Name { get; init; }
    public required FormattedContent Title  { get; init; }
    public required FormattedContent Description { get; init; }
}