using Domain.DataTypes;

namespace Domain.Entities;

public sealed class OrganizationConnectionDto : BaseEntityDto
{
    public required OrganizationDto Organization { get; init; }
    public required OrganizationPosition[] OrganizationPositions { get; init; }
}