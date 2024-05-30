using Domain.DataTypes;

namespace Application.Models.ApiModels;

public sealed class ApiOrganizationConnection : ApiBaseEntity
{
    public required ApiOrganization Organization { get; init; }
    public required OrganizationPosition[] OrganizationPositions { get; init; }
}