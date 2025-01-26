namespace Application.Models.ApiModels;

public sealed class ApiWorkAmountSpecification : ApiBaseEntity
{
    public required string Value { get; init; }
}