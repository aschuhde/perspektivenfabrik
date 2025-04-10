using Domain.DataTypes;

namespace Domain.Entities;

public sealed class DescriptionTypeDto : BaseEntityWithIdDto
{
    public required string Name { get; init; }
    public required FormattedTitle DescriptionTitle { get; init; } 
}