using Domain.DataTypes;

namespace Application.Models.ApiModels;

public sealed class ApiSkillSpecification : ApiBaseEntityWithId
{
    public required string Name { get; init; }
    public TranslationValue[] NameTranslations { get; set; } = [];
    public required FormattedContent Title { get; init; }
}