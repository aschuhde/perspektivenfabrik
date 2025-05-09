using Application.ApiDataTypes;
using Domain.DataTypes;

namespace Application.Models.ApiModels;

public sealed class ApiSkillSpecification : ApiBaseEntityWithId
{
    public required string Name { get; init; }
    public ApiTranslationValue[] NameTranslations { get; set; } = [];
    public required FormattedContent Title { get; init; }
}