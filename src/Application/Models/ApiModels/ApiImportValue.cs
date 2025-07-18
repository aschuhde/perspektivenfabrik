namespace Application.Models.ApiModels;

public class ApiImportValue
{
    public required string GermanName { get; init; }
    public required string ItalianName { get; init; }
    public Guid? EntityId { get; init; }
    public bool ToDelete { get; init; } = false;
}