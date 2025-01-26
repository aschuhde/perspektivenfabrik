using System.Text.Json.Serialization;
using Domain.DataTypes;

namespace Application.Models.ApiModels;

[JsonDerivedType(typeof(ApiTimeSpecification), typeDiscriminator: "base")]
[JsonDerivedType(typeof(ApiTimeSpecificationPeriod), typeDiscriminator: "period")]
[JsonDerivedType(typeof(ApiTimeSpecificationMoment), typeDiscriminator: "moment")]
public class ApiTimeSpecification : ApiBaseEntity
{
    
}

public sealed class ApiTimeSpecificationPeriod : ApiTimeSpecification
{
    public required ApiTimeSpecificationMoment Start { get; init; }
    public required ApiTimeSpecificationMoment End { get; init; }
}

[JsonDerivedType(typeof(ApiTimeSpecificationMoment), typeDiscriminator: "base")]
[JsonDerivedType(typeof(ApiTimeSpecificationDate), typeDiscriminator: "date")]
[JsonDerivedType(typeof(ApiTimeSpecificationDateTime), typeDiscriminator: "dateTime")]
[JsonDerivedType(typeof(ApiTimeSpecificationMonth), typeDiscriminator: "month")]
public class ApiTimeSpecificationMoment : ApiTimeSpecification
{
    
}

public sealed class ApiTimeSpecificationDate : ApiTimeSpecificationMoment
{
    public required DateOnly Date { get; init; }
}

public sealed class ApiTimeSpecificationDateTime : ApiTimeSpecificationMoment
{
    public required DateTimeOffset Date { get; init; }
}

public sealed class ApiTimeSpecificationMonth : ApiTimeSpecificationMoment
{
    public required Month Month { get; init; }
}