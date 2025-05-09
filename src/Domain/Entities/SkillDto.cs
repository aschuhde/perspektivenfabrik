using Domain.DataTypes;

namespace Domain.Entities;

public class SkillDto : BaseEntityWithIdDto
{
    public required string Name { get; init; }

    public TranslationValue[] NameTranslations { get; set; } = [];

    public SkillDto ApplyTranslations(FieldTranslationDto[] fieldTranslations)
    {
        NameTranslations = fieldTranslations.Where(x => x.CorrelatedEntityId == EntityId).Select(x => x.ToTranslationValue()).ToArray();
        return this;       
    }
}