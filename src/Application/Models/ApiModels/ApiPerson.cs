namespace Application.Models.ApiModels;

public class ApiPerson : ApiBaseEntity
{
    public string? Firstname { get; init; }
    public string? Lastname { get; init; }
    public string? Email { get; init; }

    public ApiOrganizationConnection[] ConnectedOrganizations { get; init; } = Array.Empty<ApiOrganizationConnection>();

    public static ApiPerson WithUserId(Guid userId) => new () { EntityId = userId };
    
}
