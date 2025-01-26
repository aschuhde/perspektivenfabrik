namespace Domain.Entities;

public sealed class WorkAmountSpecificationDto : BaseEntityDto
{
    public required string Value { get; init; }
}