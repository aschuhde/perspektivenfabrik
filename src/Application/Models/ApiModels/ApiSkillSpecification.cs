using Domain.DataTypes;

namespace Application.Models.ApiModels;

public sealed class ApiSkillSpecification : ApiBaseEntity
{
    public required string Name { get; init; }
    public required FormattedContent Title { get; init; }
}