using Domain.DataTypes;

namespace Domain.Entities;

public sealed class DescriptionSpecificationDto : BaseEntityWithIdDto
{
    public required DescriptionTypeDto Type { get; init; }
    public required FormattedContent Content { get; init; }
}