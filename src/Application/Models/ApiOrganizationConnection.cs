using Domain.DataTypes;

namespace Application.Models;

public sealed class ApiOrganizationConnection : ApiBaseEntity
{
    public required ApiOrganization Organization { get; init; }
    public required OrganizationPosition[] OrganizationPositions { get; init; }
}