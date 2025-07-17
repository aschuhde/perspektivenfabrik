namespace Domain.DataTypes;

public sealed class FormattedContent
{
    public required string RawContentString { get; set; }
    public TranslationValue[] ContentTranslations { get; set; } = [];
}