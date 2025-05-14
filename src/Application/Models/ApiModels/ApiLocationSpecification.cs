using System.Text.Json.Serialization;
using Domain.DataTypes;

namespace Application.Models.ApiModels;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ApiLocationSpecificationTypes
{
    Base, Remote, Region, Coordinates, Address, Name, EntireProvince
}
[JsonPolymorphic(TypeDiscriminatorPropertyName = "classType")]
[JsonDerivedType(typeof(ApiLocationSpecification), typeDiscriminator: nameof(ApiLocationSpecificationTypes.Base))]
[JsonDerivedType(typeof(ApiLocationSpecificationRemote), typeDiscriminator: nameof(ApiLocationSpecificationTypes.Remote))]
[JsonDerivedType(typeof(ApiLocationSpecificationRegion), typeDiscriminator: nameof(ApiLocationSpecificationTypes.Region))]
[JsonDerivedType(typeof(ApiLocationSpecificationCoordinates), typeDiscriminator: nameof(ApiLocationSpecificationTypes.Coordinates))]
[JsonDerivedType(typeof(ApiLocationSpecificationAddress), typeDiscriminator: nameof(ApiLocationSpecificationTypes.Address))]
[JsonDerivedType(typeof(ApiLocationSpecificationName), typeDiscriminator: nameof(ApiLocationSpecificationTypes.Name))]
[JsonDerivedType(typeof(ApiLocationSpecificationEntireProvince), typeDiscriminator: nameof(ApiLocationSpecificationTypes.EntireProvince))]
public class ApiLocationSpecification : ApiBaseEntityWithId
{
    
}

public sealed class ApiLocationSpecificationRemote : ApiLocationSpecification
{
    public required Url Link { get; init; }
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

public sealed class ApiLocationSpecificationName : ApiLocationSpecification
{
    public required PostalAddress PostalAddress { get; init; }
}

public sealed class ApiLocationSpecificationEntireProvince : ApiLocationSpecification
{
    
}