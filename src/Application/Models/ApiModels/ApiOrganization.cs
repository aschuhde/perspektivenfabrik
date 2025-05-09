using Application.ApiDataTypes;

namespace Application.Models.ApiModels;

public sealed class ApiOrganization : ApiBaseEntity
{
    public required string Name { get; init; }
    public ApiTranslationValue[] NameTranslations { get; set; } = [];
}