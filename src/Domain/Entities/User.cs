namespace Domain.Entities;

public class User : Person
{
    public required string PasswordHash { get; init; }
}
