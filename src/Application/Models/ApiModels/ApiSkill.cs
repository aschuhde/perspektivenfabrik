using Domain.DataTypes;

namespace Application.Models.ApiModels;

public class ApiSkill : ApiBaseEntityWithId
{
    public required string Name { get; init; }
    public TranslationValue[] NameTranslations { get; set; } = [];
}