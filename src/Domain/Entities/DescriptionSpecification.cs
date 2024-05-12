using Domain.DataTypes;

namespace Domain.Entities;

public sealed class DescriptionSpecification : BaseEntity
{
    public required DescriptionType Type { get; init; }
    public required FormattedContent Content { get; init; }
}