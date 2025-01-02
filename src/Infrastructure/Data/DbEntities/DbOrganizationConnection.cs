using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.DbEntities;

[Table("OrganizationConnections")]
public sealed class DbOrganizationConnection : DbEntityWithId
{
    [ForeignKey(nameof(Organization))]
    public required Guid OrganizationId { get; init; }
    public required DbOrganization? Organization { get; init; }
    public required List<DbOrganizationPositionConnection> OrganizationPositions { get; init; }
}