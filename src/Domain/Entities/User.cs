namespace Domain.Entities;

public sealed class User : Person
{
    public required string PasswordHash { get; init; }
}
