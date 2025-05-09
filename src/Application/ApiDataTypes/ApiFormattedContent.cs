namespace Application.ApiDataTypes;

public sealed class ApiFormattedContent
{
    public required string RawContentString { get; init; }
    public ApiTranslationValue[] ContentTranslations { get; set; } = [];
}