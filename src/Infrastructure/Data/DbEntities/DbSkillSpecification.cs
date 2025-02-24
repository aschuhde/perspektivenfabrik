using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure.Data.DbDataTypes;

namespace Infrastructure.Data.DbEntities;

[Table("SkillSpecifications")]
public sealed class DbSkillSpecification : DbEntityWithId
{
    [MaxLength(Constants.StringLengths.Medium)]
    public required string Name { get; init; }
    public required DbFormattedContent Title { get; init; }
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
}