namespace Domain.Entities;

public class MaterialDto : BaseEntityWithIdDto
{
    public required string Name { get; init; }
}