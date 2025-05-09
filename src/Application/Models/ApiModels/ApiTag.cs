using Application.ApiDataTypes;

namespace Application.Models.ApiModels;

public class ApiTag : ApiBaseEntityWithId
{
    public required string Name { get; init; }
    public ApiTranslationValue[] NameTranslations { get; set; } = [];
}