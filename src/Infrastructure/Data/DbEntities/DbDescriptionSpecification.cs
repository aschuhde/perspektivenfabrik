using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure.Data.DbDataTypes;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DbEntities;

[Table("DescriptionSpecifications")]
public sealed class DbDescriptionSpecification : DbEntityWithId
{
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public required DbDescriptionType Type { get; init; }
    public required DbFormattedContent Content { get; init; }

    public override void UpdateToTarget(DbEntityWithId target)
    {
      if(target is not DbDescriptionSpecification descriptionSpecification) return;
      this.Type.UpdateToTarget(descriptionSpecification.Type);
      this.Content.Update(descriptionSpecification.Content);
    }
}

[Table("DescriptionSpecificationProjectConnections")]
public sealed class DbDescriptionSpecificationProjectConnection : DbEntityWithId
{
    [ForeignKey(nameof(Project))]
    public required Guid ProjectId { get; init; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public DbProject? Project { get; init; }
    [ForeignKey(nameof(DescriptionSpecification))]
    public required Guid DescriptionSpecificationId { get; init; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public DbDescriptionSpecification? DescriptionSpecification { get; init; }

    public DbDescriptionSpecificationProjectConnection WithoutRelatedEntites()
    {
      return new DbDescriptionSpecificationProjectConnection()
      {
        ProjectId = ProjectId, DescriptionSpecificationId = DescriptionSpecificationId, EntityId = EntityId
      };
    }
}
