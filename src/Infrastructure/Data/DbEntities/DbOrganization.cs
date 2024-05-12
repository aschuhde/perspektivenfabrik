using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities;

namespace Infrastructure.Data.DbEntities;

[Table("Organizations")]
public sealed class DbOrganization : DbEntity
{
    public required string Name { get; init; }
}

[Table("OrganizationProjectConnections")]
public sealed class DbOrganizationProjectConnection : DbEntityWithId
{
    [ForeignKey(nameof(Project))]
    public required Guid ProjectId { get; init; }
    public DbProject? Project { get; init; }
    [ForeignKey(nameof(Organization))]
    public required Guid OrganizationId { get; init; }
    public DbOrganization? Organization { get; init; }
}