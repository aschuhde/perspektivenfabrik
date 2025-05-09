namespace Application.ApiDataTypes;

public sealed class ApiRegion
{
    public required string RegionName { get; init; }
    public required string AddressText { get; init; }
    public ApiTranslationValue[] RegionNameTranslations { get; set; } = [];
    public ApiTranslationValue[] AddressTextTranslations { get; set; } = [];
}