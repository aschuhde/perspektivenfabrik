using Domain.DataTypes;

namespace Domain.Entities;

public class TimeSpecification : BaseEntity
{
    
}

public sealed class TimeSpecificationPeriod : TimeSpecification
{
    public required TimeSpecificationMoment Start { get; init; }
    public required TimeSpecificationMoment End { get; init; }
}

public class TimeSpecificationMoment : TimeSpecification
{
    
}

public sealed class TimeSpecificationDate : TimeSpecificationMoment
{
    public required DateOnly Date { get; init; }
}

public sealed class TimeSpecificationDateTime : TimeSpecificationMoment
{
    public required DateTimeOffset Date { get; init; }
}

public sealed class TimeSpecificationMonth : TimeSpecificationMoment
{
    public required Month Month { get; init; }
}