namespace Domain.Entities;

public class ImportValueDto
{
    public required string GermanName { get; init; }
    public required string ItalianName { get; init; }
    public Guid? EntityId { get; init; }
    public bool ToDelete { get; init; } = false;
}