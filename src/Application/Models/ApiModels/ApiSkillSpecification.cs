using Domain.DataTypes;

namespace Application.Models.ApiModels;

public sealed class ApiSkillSpecification : ApiBaseEntityWithId
{
    public required string Name { get; init; }
    public required FormattedContent Title { get; init; }
}