using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.DbEntities;

[Table("RequirementSpecifications")]
public class DbRequirementSpecification : DbEntityWithId
{
    public required bool TimeSpecificationSameAsProject { get; set; }
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

    public override void UpdateToTarget(DbEntityWithId target)
    {
      if(target is not DbRequirementSpecification requirementSpecification) return;
      if (this.TimeSpecificationSameAsProject != requirementSpecification.TimeSpecificationSameAsProject)
      {
        this.TimeSpecificationSameAsProject = requirementSpecification.TimeSpecificationSameAsProject;
      }
      this.TimeSpecifications = this.TimeSpecifications?.GetUpdateConnections(requirementSpecification.TimeSpecifications, x => x.RequirementSpecificationId, x => x.TimeSpecificationId) ?? requirementSpecification.TimeSpecifications;
      if ( this.QuantitySpecification?.QuantitySpecificationId != requirementSpecification.QuantitySpecification?.QuantitySpecificationId)
      {
        this.QuantitySpecification = requirementSpecification.QuantitySpecification == null ? null : new DbQuantitySpecificationRequirementConnection()
        {
          QuantitySpecificationId = requirementSpecification.QuantitySpecification.QuantitySpecificationId,
          RequirementSpecificationId = this.EntityId
        };
      }
      base.UpdateToTarget(target);
    }
}

public sealed class DbRequirementSpecificationPerson : DbRequirementSpecification
{
    public required bool LocationSpecificationsSameAsProject { get; set; }
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

    public override void UpdateToTarget(DbEntityWithId target)
    {
      if(target is not DbRequirementSpecificationPerson requirementSpecification) return;
      if (this.LocationSpecificationsSameAsProject != requirementSpecification.LocationSpecificationsSameAsProject)
      {
        this.LocationSpecificationsSameAsProject = requirementSpecification.LocationSpecificationsSameAsProject;
      }
      this.SkillSpecifications = this.SkillSpecifications?.GetUpdateConnections(requirementSpecification.SkillSpecifications, x => x.RequirementSpecificationId, x => x.SkillSpecificationId) ?? requirementSpecification.SkillSpecifications;
      this.LocationSpecifications = this.LocationSpecifications?.GetUpdateConnections(requirementSpecification.LocationSpecifications, x => x.RequirementSpecificationId, x => x.LocationSpecificationId) ?? requirementSpecification.LocationSpecifications;
      if ( this.WorkAmountSpecification?.WorkAmountSpecificationId != requirementSpecification.WorkAmountSpecification?.WorkAmountSpecificationId)
      {
        this.WorkAmountSpecification = requirementSpecification.WorkAmountSpecification == null ? null : new DbWorkAmountSpecificationRequirementConnection()
        {
          WorkAmountSpecificationId = requirementSpecification.WorkAmountSpecification.WorkAmountSpecificationId,
          RequirementSpecificationPersonId = this.EntityId
        };
      }
      base.UpdateToTarget(target);
    }
}

public sealed class DbRequirementSpecificationMaterial : DbRequirementSpecification
{
    public required bool LocationSpecificationsSameAsProject { get; set; }
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
    public override void UpdateToTarget(DbEntityWithId target)
    {
      if(target is not DbRequirementSpecificationMaterial requirementSpecification) return;
      if (this.LocationSpecificationsSameAsProject != requirementSpecification.LocationSpecificationsSameAsProject)
      {
        this.LocationSpecificationsSameAsProject = requirementSpecification.LocationSpecificationsSameAsProject;
      }
      this.LocationSpecifications = this.LocationSpecifications?.GetUpdateConnections(requirementSpecification.LocationSpecifications, x => x.RequirementSpecificationId, x => x.LocationSpecificationId) ?? requirementSpecification.LocationSpecifications;
      this.MaterialSpecifications = this.MaterialSpecifications?.GetUpdateConnections(requirementSpecification.MaterialSpecifications, x => x.RequirementSpecificationId, x => x.MaterialSpecificationId) ?? requirementSpecification.MaterialSpecifications;
      base.UpdateToTarget(target);
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
