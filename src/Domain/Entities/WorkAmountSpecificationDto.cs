namespace Domain.Entities;

public sealed class WorkAmountSpecificationDto : BaseEntityWithIdDto
{
    public required string Value { get; init; }
}