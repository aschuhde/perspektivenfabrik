using Application.ApiDataTypes;

namespace Application.Models.ApiModels;

public sealed class ApiProjectTag : ApiBaseEntityWithId
{
    public required string TagName { get; init; }
    public ApiTranslationValue[] TagNameTranslations { get; set; } = [];
}