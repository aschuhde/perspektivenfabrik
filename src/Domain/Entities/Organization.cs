namespace Domain.Entities;

public sealed class Organization : BaseEntity
{
    public required string Name { get; init; }
}