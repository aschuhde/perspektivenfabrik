using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.DbEntities;

[Table("RequirementSpecifications")]
public class DbRequirementSpecification : DbEntityWithId
{
    public required bool TimeSpecificationSameAsProject { get; init; }
    public List<DbTimeSpecificationRequirementConnection>? TimeSpecifications { get; set; }
    public DbQuantitySpecificationRequirementConnection? QuantitySpecification { get; set; }

    public virtual DbRequirementSpecification WithoutRelatedEntites()
    {
      return new DbRequirementSpecification()
      {
        EntityId = this.EntityId,
        TimeSpecificationSameAsProject = this.TimeSpecificationSameAsProject
      };
    }
}

public sealed class DbRequirementSpecificationPerson : DbRequirementSpecification
{
    public required bool LocationSpecificationsSameAsProject { get; init; }
    public List<DbSkillSpecificationRequirementConnection>? SkillSpecifications { get; set; }

    public DbWorkAmountSpecificationRequirementConnection? WorkAmountSpecification { get; set; }
    public List<DbLocationSpecificationRequirementConnection>? LocationSpecifications { get; set; }
    
    public override DbRequirementSpecification WithoutRelatedEntites()
    {
      return new DbRequirementSpecificationPerson()
      {
        EntityId = this.EntityId,
        TimeSpecificationSameAsProject = this.TimeSpecificationSameAsProject,
        LocationSpecificationsSameAsProject = this.LocationSpecificationsSameAsProject
      };
    }
}

public sealed class DbRequirementSpecificationMaterial : DbRequirementSpecification
{
    public required bool LocationSpecificationsSameAsProject { get; init; }
    public List<DbMaterialSpecificationRequirementConnection>? MaterialSpecifications { get; set; }
    
    public List<DbLocationSpecificationRequirementConnection>? LocationSpecifications { get; set; }
    
    public override DbRequirementSpecification WithoutRelatedEntites()
    {
      return new DbRequirementSpecificationMaterial()
      {
        EntityId = this.EntityId,
        TimeSpecificationSameAsProject = this.TimeSpecificationSameAsProject,
        LocationSpecificationsSameAsProject = this.LocationSpecificationsSameAsProject
      };
    }
}

public sealed class DbRequirementSpecificationMoney : DbRequirementSpecification
{
  public override DbRequirementSpecification WithoutRelatedEntites()
  {
    return new DbRequirementSpecificationMoney()
    {
      EntityId = this.EntityId,
      TimeSpecificationSameAsProject = this.TimeSpecificationSameAsProject
    };
  }
}

[Table("RequirementSpecificationConnections")]
public sealed class DbRequirementSpecificationProjectConnection : DbEntityWithId
{
    [ForeignKey(nameof(Project))]
    public required Guid ProjectId { get; init; }
    public DbProject? Project { get; init; }
    [ForeignKey(nameof(RequirementSpecification))]
    public required Guid RequirementSpecificationId { get; init; }
    public DbRequirementSpecification? RequirementSpecification { get; init; }

    public DbRequirementSpecificationProjectConnection WithoutRelatedEntites()
    {
      return new DbRequirementSpecificationProjectConnection()
      {
        EntityId = this.EntityId,
        RequirementSpecificationId = this.RequirementSpecificationId,
        ProjectId = this.ProjectId
      };
    }
}
