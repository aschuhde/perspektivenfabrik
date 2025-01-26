namespace Domain.Entities;

public sealed class QuantitySpecificationDto : BaseEntityDto
{
    public required string Value { get; init; }
}