using Domain.DataTypes;

namespace Domain.Entities;

public sealed class SkillSpecificationDto : BaseEntityWithIdDto
{
    public required string Name { get; init; }
    public required FormattedContent Title { get; init; }
}