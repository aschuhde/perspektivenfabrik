namespace Domain.DataTypes;

public sealed class FormattedTitle
{
    public required string RawContentString { get; init; }
    public TranslationValue[] ContentTranslations { get; set; } = [];
}