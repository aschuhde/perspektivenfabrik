namespace Application.Models.ApiModels;

public sealed class ApiQuantitySpecification : ApiBaseEntity
{
    public required string Value { get; init; }
}