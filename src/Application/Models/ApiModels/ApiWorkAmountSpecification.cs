namespace Application.Models.ApiModels;

public sealed class ApiWorkAmountSpecification : ApiBaseEntityWithId
{
    public required string Value { get; init; }
}