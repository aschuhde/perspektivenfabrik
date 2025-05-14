using Domain.DataTypes;

namespace Application.Models.ApiModels;

public sealed class ApiMaterialSpecification : ApiBaseEntityWithId
{
    public required string Name { get; init; }
    public TranslationValue[] NameTranslations { get; set; } = [];
    public required string AmountValue { get; init; }
    public TranslationValue[] AmountValueTranslations { get; set; } = [];
    public required FormattedContent Title  { get; init; }
    public required FormattedContent Description { get; init; }
    
}