namespace Domain.DataTypes;

public sealed class Url
{
    public required string RawUrl { get; init; }
    
    public TranslationValue[] UrlTranslations { get; set; } = [];
}