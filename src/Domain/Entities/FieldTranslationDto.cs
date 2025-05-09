using Domain.DataTypes;

namespace Domain.Entities;

public class FieldTranslationDto : BaseEntityWithIdDto
{
    public required Guid GroupEntityId { get; set; }
    public required Guid CorrelatedEntityId { get; set; }
    public required string LanguageCode { get; set; }
    public required string PropertyPath { get; set; }
    public required string Content { get; set; }

    public TranslationValue ToTranslationValue() =>
        new()
        {
            LanguageCode = LanguageCode,
            Value = Content
        };
}