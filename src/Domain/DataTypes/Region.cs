namespace Domain.DataTypes;

public sealed class Region
{
    public required string RegionName { get; init; }
    public required string AddressText { get; init; }
    
    public TranslationValue[] RegionNameTranslations { get; set; } = [];
    public TranslationValue[] AddressTextTranslations { get; set; } = [];
}