namespace Application.Models.ApiModels;

public class ApiPerson : ApiBaseEntity
{
    public required string Firstname { get; init; }
    public required string Lastname { get; init; }
    public required string Email { get; init; }

    public ApiOrganizationConnection[] ConnectedOrganizations { get; init; } = Array.Empty<ApiOrganizationConnection>();
}
