namespace Application.Models.ApiModels;

public sealed class ApiMaterialSpecification : ApiBaseEntity
{
    public required string Value { get; init; }
}