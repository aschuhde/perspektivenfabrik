namespace Application.Models;

public class ApiBaseEntityWithId
{ 
    public Guid EntityId { get; init; } = Guid.NewGuid();
}