using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure.Data.DbDataTypes;

namespace Infrastructure.Data.DbEntities;

[Table("SkillSpecifications")]
public sealed class DbSkillSpecification : DbEntityWithId
{
    [MaxLength(Constants.StringLengths.Medium)]
    public required string Name { get; set; }
    public required DbFormattedContent Title { get; set; }

    public override void UpdateToTarget(DbEntityWithId target)
    {
      if( target is not DbSkillSpecification skillSpecification) return;
      if (this.Name != skillSpecification.Name)
      {
        this.Name = skillSpecification.Name;
      }
      this.Title.Update(skillSpecification.Title);
      base.UpdateToTarget(target);
    }
}


[Table("SkillSpecificationRequirementConnections")]
public sealed class DbSkillSpecificationRequirementConnection : DbEntityWithId
{
    [ForeignKey(nameof(RequirementSpecification))]
    public required Guid RequirementSpecificationId { get; init; }
    public DbRequirementSpecification? RequirementSpecification { get; init; }
    [ForeignKey(nameof(SkillSpecification))]
    public required Guid SkillSpecificationId { get; init; }
    public DbSkillSpecification? SkillSpecification { get; init; }

    public DbSkillSpecificationRequirementConnection WithoutRelatedEntites()
    {
      return new DbSkillSpecificationRequirementConnection()
      {
        EntityId = this.EntityId,
        SkillSpecificationId = this.SkillSpecificationId,
        RequirementSpecificationId = this.RequirementSpecificationId
      };
    }
}
