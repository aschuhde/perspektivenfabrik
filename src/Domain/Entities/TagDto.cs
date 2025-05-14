using Domain.DataTypes;

namespace Domain.Entities;

public class TagDto : BaseEntityWithIdDto
{
    public required string Name { get; init; }
    public TranslationValue[] NameTranslations { get; set; } = [];

    public TagDto ApplyTranslations(FieldTranslationDto[] fieldTranslations)
    {
        NameTranslations = fieldTranslations.Where(x => x.CorrelatedEntityId == EntityId).Select(x => x.ToTranslationValue()).ToArray();
        return this;       
    }
}