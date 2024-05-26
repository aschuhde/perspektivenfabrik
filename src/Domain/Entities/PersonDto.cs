namespace Domain.Entities;

public class PersonDto : BaseEntityDto
{
    public required string Firstname { get; init; }
    public required string Lastname { get; init; }
    public required string Email { get; init; }

    public OrganizationConnectionDto[] ConnectedOrganizations { get; init; } = Array.Empty<OrganizationConnectionDto>();
}
