using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DbEntities;

[Table("OrganizationConnections")]
public sealed class DbOrganizationConnection : DbEntityWithId
{
    [ForeignKey(nameof(Organization))]
    public required Guid OrganizationId { get; init; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public required DbOrganization? Organization { get; init; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public required List<DbOrganizationPositionConnection> OrganizationPositions { get; init; }
}
