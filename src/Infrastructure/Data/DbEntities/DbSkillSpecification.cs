using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.DbEntities;

[Table("SkillSpecifications")]
public sealed class DbSkillSpecification : DbEntity
{
    
}


[Table("SkillSpecificationRequirementConnections")]
public sealed class DbSkillSpecificationRequirementConnection : DbEntityWithId
{
    [ForeignKey(nameof(RequirementSpecification))]
    public required Guid RequirementSpecificationId { get; init; }
    public required DbRequirementSpecification? RequirementSpecification { get; init; }
    [ForeignKey(nameof(SkillSpecification))]
    public required Guid SkillSpecificationId { get; init; }
    public required DbSkillSpecification? SkillSpecification { get; init; }
}