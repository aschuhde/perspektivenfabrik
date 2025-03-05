using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure.Data.DbDataTypes;

namespace Infrastructure.Data.DbEntities;

[Table("MaterialSpecifications")]
public sealed class DbMaterialSpecification : DbEntityWithId
{
    [MaxLength(Constants.StringLengths.Medium)]
    public required string Name { get; set; }
    [MaxLength(Constants.StringLengths.Medium)]
    public required string AmountValue { get; set; }
    public required DbFormattedContent Title  { get; set; }
    public required DbFormattedContent Description { get; set; }

    public override void UpdateToTarget(DbEntityWithId target)
    {
      if(target is not DbMaterialSpecification materialSpecification) return;
      if (this.Name != materialSpecification.Name)
      {
        this.Name = materialSpecification.Name;
      }

      if (this.AmountValue != materialSpecification.AmountValue)
      {
        this.AmountValue = materialSpecification.AmountValue;
      }

      this.Title.Update(materialSpecification.Title);
      this.Description.Update(materialSpecification.Description);
    }
}

[Table("MaterialSpecificationRequirementConnections")]
public sealed class DbMaterialSpecificationRequirementConnection : DbEntityWithId
{
    [ForeignKey(nameof(RequirementSpecification))]
    public required Guid RequirementSpecificationId { get; init; }
    public DbRequirementSpecification? RequirementSpecification { get; init; }
    [ForeignKey(nameof(MaterialSpecification))]
    public required Guid MaterialSpecificationId { get; init; }
    public DbMaterialSpecification? MaterialSpecification { get; init; }

    public DbMaterialSpecificationRequirementConnection WithoutRelatedEntites()
    {
      return new DbMaterialSpecificationRequirementConnection()
      {
        EntityId = this.EntityId,
        MaterialSpecificationId = this.MaterialSpecificationId,
        RequirementSpecificationId = this.RequirementSpecificationId
      };
    }
}
