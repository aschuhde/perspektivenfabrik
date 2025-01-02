namespace Domain.Entities;

public class BaseEntityWithIdDto
{
    public Guid EntityId { get; init; } = Guid.NewGuid();
    public bool EntityNeedsToBeCreated { get; init; } = true;
}
