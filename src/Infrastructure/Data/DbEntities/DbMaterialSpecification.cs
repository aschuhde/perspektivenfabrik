using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.DbEntities;

[Table("MaterialSpecifications")]
public sealed class DbMaterialSpecification : DbEntity
{
    
}

[Table("MaterialSpecificationRequirementConnections")]
public sealed class DbMaterialSpecificationRequirementConnection : DbEntityWithId
{
    [ForeignKey(nameof(RequirementSpecification))]
    public required Guid RequirementSpecificationId { get; init; }
    public required DbRequirementSpecification? RequirementSpecification { get; init; }
    [ForeignKey(nameof(MaterialSpecification))]
    public required Guid MaterialSpecificationId { get; init; }
    public required DbMaterialSpecification? MaterialSpecification { get; init; }
}