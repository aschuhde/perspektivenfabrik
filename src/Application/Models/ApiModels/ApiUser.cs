namespace Application.Models.ApiModels;

public sealed class ApiUser : ApiPerson
{
    public required string PasswordHash { get; init; }
}
