using Domain.DataTypes;

namespace Application.Models.ApiModels;

public sealed class ApiOrganization : ApiBaseEntity
{
    public required string Name { get; init; }
    public TranslationValue[] NameTranslations { get; set; } = [];
}