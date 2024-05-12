using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.DbEntities;

[Table("QuantitySpecifications")]
public sealed class DbQuantitySpecification : DbEntity
{
    
}

[Table("QuantitySpecificationRequirementConnections")]
public sealed class DbQuantitySpecificationRequirementConnection : DbEntityWithId
{
    [ForeignKey(nameof(RequirementSpecification))]
    public required Guid RequirementSpecificationId { get; init; }
    public required DbRequirementSpecification? RequirementSpecification { get; init; }
    [ForeignKey(nameof(QuantitySpecification))]
    public required Guid QuantitySpecificationId { get; init; }
    public required DbQuantitySpecification? QuantitySpecification { get; init; }
}