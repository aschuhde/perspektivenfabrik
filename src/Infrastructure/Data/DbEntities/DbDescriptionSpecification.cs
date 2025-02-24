using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure.Data.DbDataTypes;

namespace Infrastructure.Data.DbEntities;

[Table("DescriptionSpecifications")]
public sealed class DbDescriptionSpecification : DbEntityWithId
{
    public required DbDescriptionType Type { get; init; }
    public required DbFormattedContent Content { get; init; }
}

[Table("DescriptionSpecificationProjectConnections")]
public sealed class DbDescriptionSpecificationProjectConnection : DbEntityWithId
{
    [ForeignKey(nameof(Project))]
    public required Guid ProjectId { get; init; }
    public DbProject? Project { get; init; }
    [ForeignKey(nameof(DescriptionSpecification))]
    public required Guid DescriptionSpecificationId { get; init; }
    public DbDescriptionSpecification? DescriptionSpecification { get; init; }
}