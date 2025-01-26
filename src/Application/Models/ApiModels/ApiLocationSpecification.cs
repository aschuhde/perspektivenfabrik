using System.Text.Json.Serialization;
using Domain.DataTypes;

namespace Application.Models.ApiModels;

[JsonDerivedType(typeof(ApiLocationSpecification), typeDiscriminator: "base")]
[JsonDerivedType(typeof(ApiLocationSpecificationRemote), typeDiscriminator: "remote")]
[JsonDerivedType(typeof(ApiLocationSpecificationRegion), typeDiscriminator: "withRegion")]
[JsonDerivedType(typeof(ApiLocationSpecificationCoordinates), typeDiscriminator: "withCoordinates")]
[JsonDerivedType(typeof(ApiLocationSpecificationAddress), typeDiscriminator: "withAddress")]
public class ApiLocationSpecification : ApiBaseEntity
{
    
}

public sealed class ApiLocationSpecificationRemote : ApiLocationSpecification
{
    
}

public sealed class ApiLocationSpecificationRegion : ApiLocationSpecification
{
    public required Region Region { get; init; }
}

public sealed class ApiLocationSpecificationCoordinates : ApiLocationSpecification
{
    public required Coordinates Coordinates { get; init; }
}

public sealed class ApiLocationSpecificationAddress : ApiLocationSpecification
{
    public required PostalAddress PostalAddress { get; init; }
}