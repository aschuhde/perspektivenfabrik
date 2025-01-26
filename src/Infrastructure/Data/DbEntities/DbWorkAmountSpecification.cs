using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.DbEntities;

[Table("WorkAmountSpecifications")]
public sealed class DbWorkAmountSpecification : DbEntity
{
    [MaxLength(Constants.StringLengths.Medium)]
    public required string Value { get; init; }
}

[Table("WorkAmountSpecificationRequirementConnections")]
public sealed class DbWorkAmountSpecificationRequirementConnection : DbEntityWithId
{
    [ForeignKey(nameof(RequirementSpecification))]
    public required Guid RequirementSpecificationId { get; init; }
    public DbRequirementSpecification? RequirementSpecification { get; init; }
    [ForeignKey(nameof(WorkAmountSpecification))]
    public required Guid WorkAmountSpecificationId { get; init; }
    public DbWorkAmountSpecification? WorkAmountSpecification { get; init; }
}