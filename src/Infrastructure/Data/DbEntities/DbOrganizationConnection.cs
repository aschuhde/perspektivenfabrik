using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure.Data.DbDataTypes;

namespace Infrastructure.Data.DbEntities;

[Table("OrganizationConnections")]
public sealed class DbOrganizationConnection : DbEntityWithId
{
    [ForeignKey(nameof(Organization))]
    public required Guid OrganizationId { get; init; }
    public required DbOrganization? Organization { get; init; }
    public required DbOrganizationPositionConnection[] OrganizationPositions { get; init; }
}