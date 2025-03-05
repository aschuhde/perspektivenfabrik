using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;
using Infrastructure.Data.DbDataTypes;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DbEntities;

[Table("GraphicsSpecifications")]
public sealed class DbGraphicsSpecification : DbEntityWithId
{
    public required GraphicsType Type { get; set; }
    public required DbGraphicsContent Content { get; set; }

    public override void UpdateToTarget(DbEntityWithId target)
    {
      if(target is not DbGraphicsSpecification graphicsSpecification) return;
      if (this.Type != graphicsSpecification.Type)
      {
        this.Type = graphicsSpecification.Type;
      }
      this.Content.Update(graphicsSpecification.Content);
    }
}

[Table("GraphicsSpecificationProjectConnections")]
public sealed class DbGraphicsSpecificationProjectConnection : DbEntityWithId
{
    [ForeignKey(nameof(Project))]
    public required Guid ProjectId { get; init; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public DbProject? Project { get; init; }
    [ForeignKey(nameof(GraphicsSpecification))]
    public required Guid GraphicsSpecificationId { get; init; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public DbGraphicsSpecification? GraphicsSpecification { get; init; }

    public DbGraphicsSpecificationProjectConnection WithoutRelatedEntites()
    {
      return new DbGraphicsSpecificationProjectConnection()
      {
        ProjectId = ProjectId, GraphicsSpecificationId = GraphicsSpecificationId, EntityId = EntityId
      };
    }
}
