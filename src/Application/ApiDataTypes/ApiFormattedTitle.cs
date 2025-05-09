namespace Application.ApiDataTypes;

public sealed class ApiFormattedTitle
{
    public required string RawContentString { get; init; }
    public ApiTranslationValue[] ContentTranslations { get; set; } = [];
}