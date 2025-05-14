using Domain.DataTypes;

namespace Domain.Entities;

public sealed class QuantitySpecificationDto : BaseEntityWithIdDto
{
    public required string Value { get; init; }
    public TranslationValue[] ValueTranslations { get; set; } = [];
}