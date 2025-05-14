using Domain.DataTypes;
using Domain.Extensions;

namespace Domain.Entities;

public sealed class ProjectTagDto : BaseEntityWithIdDto
{
    public required string TagName { get; init; }
    public TranslationValue[] TagNameTranslations { get; set; } = [];

    public void ApplyTranslations(FieldTranslationDto[] fieldTranslations)
    {
        TagNameTranslations = fieldTranslations.Where(x => x.CorrelatedEntityId == EntityId && x.PropertyPath == nameof(TagName)).Select(x => x.ToTranslationValue()).ToArray();
    }

    public FieldTranslationDto[] CollectTranslations(Guid projectId)
    {
        return TagNameTranslations.CreateFieldTranslationDtos(projectId, EntityId, nameof(TagName));
    }
}