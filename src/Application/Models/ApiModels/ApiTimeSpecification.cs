using System.Text.Json.Serialization;
using Domain.DataTypes;

namespace Application.Models.ApiModels;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ApiTimeSpecificationTypes
{
    Base, Period, Moment, Date, DateTime, Month
}
[JsonPolymorphic(TypeDiscriminatorPropertyName = "classType")]
[JsonDerivedType(typeof(ApiTimeSpecification), typeDiscriminator: nameof(ApiTimeSpecificationTypes.Base))]
[JsonDerivedType(typeof(ApiTimeSpecificationPeriod), typeDiscriminator: nameof(ApiTimeSpecificationTypes.Period))]
[JsonDerivedType(typeof(ApiTimeSpecificationMoment), typeDiscriminator: nameof(ApiTimeSpecificationTypes.Moment))]
[JsonDerivedType(typeof(ApiTimeSpecificationDate), typeDiscriminator: nameof(ApiTimeSpecificationTypes.Date))]
[JsonDerivedType(typeof(ApiTimeSpecificationDateTime), typeDiscriminator: nameof(ApiTimeSpecificationTypes.DateTime))]
[JsonDerivedType(typeof(ApiTimeSpecificationMonth), typeDiscriminator: nameof(ApiTimeSpecificationTypes.Month))]
public class ApiTimeSpecification : ApiBaseEntityWithId
{
    
}

public sealed class ApiTimeSpecificationPeriod : ApiTimeSpecification
{
    public required ApiTimeSpecificationMoment Start { get; init; }
    public required ApiTimeSpecificationMoment End { get; init; }
}

[JsonPolymorphic(TypeDiscriminatorPropertyName = "classType")]
[JsonDerivedType(typeof(ApiTimeSpecificationDate), typeDiscriminator: nameof(ApiTimeSpecificationTypes.Date))]
[JsonDerivedType(typeof(ApiTimeSpecificationDateTime), typeDiscriminator: nameof(ApiTimeSpecificationTypes.DateTime))]
[JsonDerivedType(typeof(ApiTimeSpecificationMonth), typeDiscriminator: nameof(ApiTimeSpecificationTypes.Month))]
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