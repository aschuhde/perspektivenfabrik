using Application.ApiDataTypes;
using Domain.DataTypes;

namespace Application.Models.ApiModels;

public sealed class ApiQuantitySpecification : ApiBaseEntityWithId
{
    public required string Value { get; init; }
    public ApiTranslationValue[] ValueTranslations { get; set; } = [];
}