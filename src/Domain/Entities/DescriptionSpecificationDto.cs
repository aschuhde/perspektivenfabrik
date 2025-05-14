using Domain.DataTypes;
using Domain.Extensions;

namespace Domain.Entities;

public sealed class DescriptionSpecificationDto : BaseEntityWithIdDto
{
    public required DescriptionTypeDto Type { get; init; }
    public required FormattedContent Content { get; init; }

    public void ApplyTranslations(FieldTranslationDto[] fieldTranslations)
    {
        Content.ContentTranslations = fieldTranslations.Where(x => x.CorrelatedEntityId == EntityId && x.PropertyPath == nameof(Content)).Select(x => x.ToTranslationValue()).ToArray();
    }

    public FieldTranslationDto[] CollectTranslations(Guid projectId)
    {
        return Content.ContentTranslations.CreateFieldTranslationDtos(projectId, EntityId, nameof(Content));
    }
}