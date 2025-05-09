using Domain.DataTypes;

namespace Domain.Entities;

public sealed class SkillSpecificationDto : BaseEntityWithIdDto
{
    public required string Name { get; init; }
    public TranslationValue[] NameTranslations { get; set; } = [];
    public required FormattedContent Title { get; init; }

    public void ApplyTranslations(FieldTranslationDto[] fieldTranslations)
    {
        var translations = fieldTranslations.Where(x => x.CorrelatedEntityId == EntityId).ToArray();
        NameTranslations = translations.Where(x => x.PropertyPath == nameof(Name)).Select(x => x.ToTranslationValue()).ToArray();
        Title.ContentTranslations = translations.Where(x => x.PropertyPath == nameof(Title)).Select(x => x.ToTranslationValue()).ToArray();
    }
}