using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure.Data.DbDataTypes;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DbEntities;

[Table("LocationSpecifications")]
public class DbLocationSpecification : DbEntityWithId
{
  
}

public sealed class DbLocationSpecificationRemote : DbLocationSpecification
{
    public required DbUrl Link { get; init; }
    public override void UpdateToTarget(DbEntityWithId target)
    {
      if(target is not DbLocationSpecificationRemote remote) return;
      this.Link.Update(remote.Link);
    }
}

public sealed class DbLocationSpecificationRegion : DbLocationSpecification
{
    public required DbRegion Region { get; init; }
    public override void UpdateToTarget(DbEntityWithId target)
    {
      if(target is not DbLocationSpecificationRegion targetEntity) return;
      this.Region.Update(targetEntity.Region);
    }
}

public sealed class DbLocationSpecificationCoordinates : DbLocationSpecification
{
    public required DbCoordinates Coordinates { get; init; }
    public override void UpdateToTarget(DbEntityWithId target)
    {
      if(target is not DbLocationSpecificationCoordinates targetEntity) return;
      this.Coordinates.Update(targetEntity.Coordinates);
    }
}

public sealed class DbLocationSpecificationAddress : DbLocationSpecification
{
    public required DbPostalAddress PostalAddress { get; init; }
    public override void UpdateToTarget(DbEntityWithId target)
    {
      if(target is not DbLocationSpecificationAddress targetEntity) return;
      this.PostalAddress.Update(targetEntity.PostalAddress);
    }
}

public sealed class DbLocationSpecificationName : DbLocationSpecification
{
    public required DbPostalAddress PostalAddress { get; init; }
    public override void UpdateToTarget(DbEntityWithId target)
    {
        if(target is not DbLocationSpecificationName targetEntity) return;
        this.PostalAddress.Update(targetEntity.PostalAddress);
    }
}

public sealed class DbLocationSpecificationEntireProvince : DbLocationSpecification
{
    
}

[Table("LocationSpecificationProjectConnections")]
public sealed class DbLocationSpecificationProjectConnection : DbEntityWithId
{
    [ForeignKey(nameof(Project))]
    public required Guid ProjectId { get; init; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public DbProject? Project { get; init; }
    [ForeignKey(nameof(LocationSpecification))]
    public required Guid LocationSpecificationId { get; init; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public DbLocationSpecification? LocationSpecification { get; init; }
    
    public DbLocationSpecificationProjectConnection WithoutRelatedEntites()
    {
      return new DbLocationSpecificationProjectConnection
      {
        EntityId = this.EntityId,
        ProjectId = this.ProjectId,
        LocationSpecificationId = this.LocationSpecificationId
      };
    }
}

[Table("LocationSpecificationRequirementConnections")]
public sealed class DbLocationSpecificationRequirementConnection : DbEntityWithId
{
    [ForeignKey(nameof(RequirementSpecification))]
    public required Guid RequirementSpecificationId { get; init; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public DbRequirementSpecification? RequirementSpecification { get; init; }
    [ForeignKey(nameof(LocationSpecification))]
    public required Guid LocationSpecificationId { get; init; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public DbLocationSpecification? LocationSpecification { get; init; }
    
    public DbLocationSpecificationRequirementConnection WithoutRelatedEntites()
    {
      return new DbLocationSpecificationRequirementConnection
      {
        EntityId = this.EntityId,
        RequirementSpecificationId = this.RequirementSpecificationId,
        LocationSpecificationId = this.LocationSpecificationId
      };
    }
}
