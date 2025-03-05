using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure.Data.DbDataTypes;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DbEntities;

[Table("OrganizationPositionConnections")]
public sealed class DbOrganizationPositionConnection : DbEntityWithId
{
    [ForeignKey(nameof(Organization))]
    public required Guid OrganizationId { get; init; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public required DbOrganization Organization { get; init; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    
    public required DbOrganizationPosition OrganizationPosition { get; init; }
}
