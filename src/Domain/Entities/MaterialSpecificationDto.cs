using Domain.DataTypes;

namespace Domain.Entities;

public sealed class MaterialSpecificationDto : BaseEntityWithIdDto
{
    public required string Name { get; init; }
    public TranslationValue[] NameTranslations { get; set; } = [];
    public required string AmountValue { get; init; }
    public TranslationValue[] AmountValueTranslations { get; set; } = [];
    public required FormattedContent Title  { get; init; }
    public required FormattedContent Description { get; init; }

    public void ApplyTranslations(FieldTranslationDto[] fieldTranslations)
    {
        var translations = fieldTranslations.Where(x => x.CorrelatedEntityId == EntityId).ToArray();
        NameTranslations = translations.Where(x => x.PropertyPath == nameof(Name)).Select(x => x.ToTranslationValue()).ToArray();
        AmountValueTranslations = translations.Where(x => x.PropertyPath == nameof(AmountValue)).Select(x => x.ToTranslationValue()).ToArray();
        Title.ContentTranslations = translations.Where(x => x.PropertyPath == nameof(Title)).Select(x => x.ToTranslationValue()).ToArray();
        Description.ContentTranslations = translations.Where(x => x.PropertyPath == nameof(Description)).Select(x => x.ToTranslationValue()).ToArray();
    }
}