using Domain.DataTypes;

namespace Application.Models.ApiModels;

public sealed class ApiQuantitySpecification : ApiBaseEntityWithId
{
    public required string Value { get; init; }
    public TranslationValue[] ValueTranslations { get; set; } = [];
}