using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure.Data.DbDataTypes;

namespace Infrastructure.Data.DbEntities;

[Table("OrganizationPositionConnections")]
public sealed class DbOrganizationPositionConnection : DbEntity
{
    [ForeignKey(nameof(Organization))]
    public required Guid OrganizationId { get; init; }
    public required DbOrganization Organization { get; init; }
    
    public required DbOrganizationPosition OrganizationPosition { get; init; }
}