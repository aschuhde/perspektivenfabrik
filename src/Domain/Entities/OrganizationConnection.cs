using Domain.DataTypes;

namespace Domain.Entities;

public sealed class OrganizationConnection : BaseEntity
{
    public required Organization Organization { get; init; }
    public required OrganizationPosition[] OrganizationPositions { get; init; }
}