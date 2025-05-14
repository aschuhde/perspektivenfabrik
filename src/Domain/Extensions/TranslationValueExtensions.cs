using Domain.DataTypes;
using Domain.Entities;

namespace Domain.Extensions;

public static class TranslationValueExtensions
{
    public static FieldTranslationDto[] CreateFieldTranslationDtos(this TranslationValue[] translationValues, Guid projectEntityId,
        Guid correlatedEntityId, string propertyPath)
    {
        return translationValues.Select(x => new FieldTranslationDto()
        {
            Content = x.Value,
            LanguageCode = x.LanguageCode,
            CorrelatedEntityId = correlatedEntityId,
            GroupEntityId = projectEntityId,
            PropertyPath = propertyPath
        }).ToArray();
    }
}