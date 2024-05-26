namespace Application.Models;

public sealed class ApiUser : ApiPerson
{
    public required string PasswordHash { get; init; }
}
