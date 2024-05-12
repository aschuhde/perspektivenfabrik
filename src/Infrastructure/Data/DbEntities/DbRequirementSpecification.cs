using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.DbEntities;

[Table("RequirementSpecifications")]
public class DbRequirementSpecification : DbEntity
{
    public required bool TimeSpecificationSameAsProject { get; init; }

    public DbTimeSpecificationRequirementConnection[] TimeSpecifications { get; set; } =
        Array.Empty<DbTimeSpecificationRequirementConnection>();
    public DbQuantitySpecificationRequirementConnection? QuantitySpecification { get; set; }
}

public sealed class DbRequirementSpecificationPerson : DbRequirementSpecification
{
    public DbSkillSpecificationRequirementConnection[] SkillSpecifications { get; set; } =
        Array.Empty<DbSkillSpecificationRequirementConnection>();

    public DbWorkAmountSpecificationRequirementConnection[] WorkAmountSpecifications { get; set; } =
        Array.Empty<DbWorkAmountSpecificationRequirementConnection>();
}

public sealed class DbRequirementSpecificationMaterial : DbRequirementSpecification
{
    public DbMaterialSpecificationRequirementConnection[] MaterialSpecifications { get; set; } =
        Array.Empty<DbMaterialSpecificationRequirementConnection>();
}

public sealed class DbRequirementSpecificationMoney : DbRequirementSpecification
{
    public DbMaterialSpecificationRequirementConnection[] MaterialSpecifications { get; set; } =
        Array.Empty<DbMaterialSpecificationRequirementConnection>();
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