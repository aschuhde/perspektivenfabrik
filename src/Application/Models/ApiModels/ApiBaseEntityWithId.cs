namespace Application.Models.ApiModels;

public class ApiBaseEntityWithId
{ 
    public Guid EntityId { get; init; } = Guid.NewGuid();
}