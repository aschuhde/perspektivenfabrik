using Domain.DataTypes;

namespace Application.Models.ApiModels;

public sealed class ApiOrganizationConnection : ApiBaseEntityWithId
{
    public required ApiOrganization Organization { get; init; }
    public required OrganizationPosition[] OrganizationPositions { get; init; }
}