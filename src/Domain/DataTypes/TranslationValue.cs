namespace Domain.DataTypes;

public class TranslationValue
{
    public required string Value { get; set; }
    public required string LanguageCode { get; init; }
}