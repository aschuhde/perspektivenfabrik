using Domain.DataTypes;

namespace Domain.Entities;

public sealed class ProjectTagDto : BaseEntityWithIdDto
{
    public required string TagName { get; init; }
    public TranslationValue[] TagNameTranslations { get; set; } = [];

    public void ApplyTranslations(FieldTranslationDto[] fieldTranslations)
    {
        TagNameTranslations = fieldTranslations.Where(x => x.CorrelatedEntityId == x.EntityId && x.PropertyPath == nameof(TagName)).Select(x => x.ToTranslationValue()).ToArray();
    }
}