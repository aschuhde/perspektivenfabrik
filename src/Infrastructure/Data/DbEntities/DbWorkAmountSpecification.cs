using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.DbEntities;

[Table("WorkAmountSpecifications")]
public sealed class DbWorkAmountSpecification : DbEntity
{
    
}

[Table("WorkAmountSpecificationRequirementConnections")]
public sealed class DbWorkAmountSpecificationRequirementConnection : DbEntityWithId
{
    [ForeignKey(nameof(RequirementSpecification))]
    public required Guid RequirementSpecificationId { get; init; }
    public required DbRequirementSpecification? RequirementSpecification { get; init; }
    [ForeignKey(nameof(WorkAmountSpecification))]
    public required Guid WorkAmountSpecificationId { get; init; }
    public required DbWorkAmountSpecification? WorkAmountSpecification { get; init; }
}