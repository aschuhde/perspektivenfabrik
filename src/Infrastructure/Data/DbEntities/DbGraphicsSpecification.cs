using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;
using Infrastructure.Data.DbDataTypes;

namespace Infrastructure.Data.DbEntities;

[Table("GraphicsSpecifications")]
public sealed class DbGraphicsSpecification : DbEntityWithId
{
    public required GraphicsType Type { get; init; }
    public required DbGraphicsContent Content { get; init; }
}

[Table("GraphicsSpecificationProjectConnections")]
public sealed class DbGraphicsSpecificationProjectConnection : DbEntityWithId
{
    [ForeignKey(nameof(Project))]
    public required Guid ProjectId { get; init; }
    public DbProject? Project { get; init; }
    [ForeignKey(nameof(GraphicsSpecification))]
    public required Guid GraphicsSpecificationId { get; init; }
    public DbGraphicsSpecification? GraphicsSpecification { get; init; }
}