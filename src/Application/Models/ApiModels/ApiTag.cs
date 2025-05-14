using Domain.DataTypes;

namespace Application.Models.ApiModels;

public class ApiTag : ApiBaseEntityWithId
{
    public required string Name { get; init; }
    public TranslationValue[] NameTranslations { get; set; } = [];
}