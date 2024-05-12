namespace Domain.Entities;

public class BaseEntityWithId
{
    public Guid EntityId { get; init; } = Guid.NewGuid();
}