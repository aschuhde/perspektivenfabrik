using Domain.DataTypes;

namespace Domain.Entities;

public class LocationSpecificationDto : BaseEntityWithIdDto
{
    
}

public sealed class LocationSpecificationDtoRemote : LocationSpecificationDto
{
    public required Url Link { get; init; }
}

public sealed class LocationSpecificationDtoRegion : LocationSpecificationDto
{
    public required Region Region { get; init; }
}

public sealed class LocationSpecificationDtoCoordinates : LocationSpecificationDto
{
    public required Coordinates Coordinates { get; init; }
}

public sealed class LocationSpecificationDtoAddress : LocationSpecificationDto
{
    public required PostalAddress PostalAddress { get; init; }
}