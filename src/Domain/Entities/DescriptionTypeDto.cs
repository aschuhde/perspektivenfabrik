using Domain.DataTypes;

namespace Domain.Entities;

public sealed class DescriptionTypeDto : BaseEntityDto
{
    public required string Name { get; init; }
    public required FormattedTitle DescriptionTitle { get; init; } 
}