using Domain.DataTypes;

namespace Domain.Entities;

public class LocationSpecification : BaseEntity
{
    
}

public sealed class LocationSpecificationRemote : LocationSpecification
{
    
}

public sealed class LocationSpecificationRegion : LocationSpecification
{
    public required Region Region { get; init; }
}

public sealed class LocationSpecificationCoordinates : LocationSpecification
{
    public required Coordinates Coordinates { get; init; }
}

public sealed class LocationSpecificationAddress : LocationSpecification
{
    public required PostalAddress PostalAddress { get; init; }
}