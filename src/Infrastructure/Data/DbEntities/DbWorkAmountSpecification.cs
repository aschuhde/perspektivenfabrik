using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DbEntities;

[Table("WorkAmountSpecifications")]
public sealed class DbWorkAmountSpecification : DbEntityWithId
{
    [MaxLength(Constants.StringLengths.Medium)]
    public required string Value { get; set; }

    public override void UpdateToTarget(DbEntityWithId target)
    {
      if(target is not DbWorkAmountSpecification workAmountSpecification) return;
      if (this.Value != workAmountSpecification.Value)
      {
        this.Value = workAmountSpecification.Value;
      }
    }
}

[Table("WorkAmountSpecificationRequirementConnections")]
public sealed class DbWorkAmountSpecificationRequirementConnection : DbEntityWithId
{
    [ForeignKey(nameof(RequirementSpecificationPerson))]
    public required Guid RequirementSpecificationPersonId { get; init; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public DbRequirementSpecificationPerson? RequirementSpecificationPerson { get; init; }
    [ForeignKey(nameof(WorkAmountSpecification))]
    public required Guid WorkAmountSpecificationId { get; init; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public DbWorkAmountSpecification? WorkAmountSpecification { get; init; }

    public DbWorkAmountSpecificationRequirementConnection WithoutRelatedEntites()
    {
      return new DbWorkAmountSpecificationRequirementConnection()
      {
        EntityId = EntityId,
        WorkAmountSpecificationId = WorkAmountSpecificationId,
        RequirementSpecificationPersonId = RequirementSpecificationPersonId
      };
    }
}
