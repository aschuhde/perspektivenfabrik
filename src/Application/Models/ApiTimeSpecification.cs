using Domain.DataTypes;

namespace Application.Models;

public class ApiTimeSpecification : ApiBaseEntity
{
    
}

public sealed class ApiTimeSpecificationPeriod : ApiTimeSpecification
{
    public required ApiTimeSpecificationMoment Start { get; init; }
    public required ApiTimeSpecificationMoment End { get; init; }
}

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