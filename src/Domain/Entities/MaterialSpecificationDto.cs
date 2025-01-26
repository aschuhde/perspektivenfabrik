namespace Domain.Entities;

public sealed class MaterialSpecificationDto : BaseEntityDto
{
    public required string Value { get; init; }
}