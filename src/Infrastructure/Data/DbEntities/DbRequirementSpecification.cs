using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.DbEntities;

[Table("RequirementSpecifications")]
public class DbRequirementSpecification : DbEntity
{
    public required bool TimeSpecificationSameAsProject { get; init; }
    public required DbTimeSpecificationRequirementConnection[] TimeSpecifications { get; init; }
    public required DbQuantitySpecificationRequirementConnection QuantitySpecification { get; init; }
}

public sealed class DbRequirementSpecificationPerson : DbRequirementSpecification
{
    public required DbSkillSpecificationRequirementConnection[] SkillSpecifications { get; init; }
    public required DbWorkAmountSpecificationRequirementConnection[] WorkAmountSpecifications { get; init; }
}

public sealed class DbRequirementSpecificationMaterial : DbRequirementSpecification
{
    public required DbMaterialSpecificationRequirementConnection[] MaterialSpecifications { get; init; }
}

public sealed class DbRequirementSpecificationMoney : DbRequirementSpecification
{
    public required DbMaterialSpecificationRequirementConnection[] MaterialSpecifications { get; init; }
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
}