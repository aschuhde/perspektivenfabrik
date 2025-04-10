using Riok.Mapperly.Abstractions;

namespace Domain.Entities;

public class BaseEntityWithIdDto
{
    public Guid EntityId { get; init; } = Guid.NewGuid();
}
