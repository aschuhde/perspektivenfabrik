namespace Domain.Entities;

public class Person : BaseEntity
{
    public required string Firstname { get; init; }
    public required string Lastname { get; init; }
    public required string Email { get; init; }
}
