using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.DbEntities;

[Table("Organizations")]
public sealed class DbOrganization : DbEntity
{
    [MaxLength(Constants.StringLengths.Medium)]
    public required string Name { get; set; }

    public override void UpdateToTarget(DbEntityWithId target)
    {
      if(target is not DbOrganization organization) return;
      if (this.Name != organization.Name)
      {
        this.Name = organization.Name;
      }
      base.UpdateToTarget(target);
    }
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
