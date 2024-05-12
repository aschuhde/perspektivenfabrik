using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure.Data.DbDataTypes;

namespace Infrastructure.Data.DbEntities;

[Table("LocationSpecifications")]
public class DbLocationSpecification : DbEntity
{
    
}

public sealed class DbLocationSpecificationRemote : DbLocationSpecification
{
    
}

public sealed class DbLocationSpecificationRegion : DbLocationSpecification
{
    public required DbRegion Region { get; init; }
}

public sealed class DbLocationSpecificationCoordinates : DbLocationSpecification
{
    public required DbCoordinates Coordinates { get; init; }
}

public sealed class DbLocationSpecificationAddress : DbLocationSpecification
{
    public required DbPostalAddress PostalAddress { get; init; }
}

[Table("LocationSpecificationProjectConnections")]
public sealed class DbLocationSpecificationProjectConnection : DbEntityWithId
{
    [ForeignKey(nameof(Project))]
    public required Guid ProjectId { get; init; }
    public DbProject? Project { get; init; }
    [ForeignKey(nameof(LocationSpecification))]
    public required Guid LocationSpecificationId { get; init; }
    public DbLocationSpecification? LocationSpecification { get; init; }
}
