namespace Domain.Entities;

public class TagDto : BaseEntityWithIdDto
{
    public required string Name { get; init; }
}