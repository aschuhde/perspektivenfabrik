namespace Domain.Entities;

public class ProjectMetadata : BaseEntityWithIdDto
{
    public required string Name { get; init; }
    public required string Title { get; init; }
}