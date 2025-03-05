using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DbEntities;

[Table("QuantitySpecifications")]
public sealed class DbQuantitySpecification : DbEntityWithId
{
    [MaxLength(Constants.StringLengths.Medium)]
    public required string Value { get; set; }

    public override void UpdateToTarget(DbEntityWithId target)
    {
      if(target is not DbQuantitySpecification quantitySpecification) return;
      if (this.Value != quantitySpecification.Value)
      {
        this.Value = quantitySpecification.Value;
      }
    }
}

[Table("QuantitySpecificationRequirementConnections")]
public sealed class DbQuantitySpecificationRequirementConnection : DbEntityWithId
{
    [ForeignKey(nameof(RequirementSpecification))]
    public required Guid RequirementSpecificationId { get; init; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public DbRequirementSpecification? RequirementSpecification { get; init; }
    [ForeignKey(nameof(QuantitySpecification))]
    public required Guid QuantitySpecificationId { get; init; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public DbQuantitySpecification? QuantitySpecification { get; init; }

    public DbQuantitySpecificationRequirementConnection WithoutRelatedEntites()
    {
      return new DbQuantitySpecificationRequirementConnection()
      {
        EntityId = this.EntityId,
        QuantitySpecificationId = this.QuantitySpecificationId,
        RequirementSpecificationId = this.RequirementSpecificationId
      };
    }
}
