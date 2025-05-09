namespace Domain.DataTypes;

public sealed class FormattedContent
{
    public required string RawContentString { get; init; }
    public TranslationValue[] ContentTranslations { get; set; } = [];
}