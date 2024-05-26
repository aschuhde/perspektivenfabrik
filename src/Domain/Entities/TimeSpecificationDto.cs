using Domain.DataTypes;

namespace Domain.Entities;

public class TimeSpecificationDto : BaseEntityDto
{
    
}

public sealed class TimeSpecificationDtoPeriod : TimeSpecificationDto
{
    public required TimeSpecificationDtoMoment Start { get; init; }
    public required TimeSpecificationDtoMoment End { get; init; }
}

public class TimeSpecificationDtoMoment : TimeSpecificationDto
{
    
}

public sealed class TimeSpecificationDtoDate : TimeSpecificationDtoMoment
{
    public required DateOnly Date { get; init; }
}

public sealed class TimeSpecificationDtoDateTime : TimeSpecificationDtoMoment
{
    public required DateTimeOffset Date { get; init; }
}

public sealed class TimeSpecificationDtoMonth : TimeSpecificationDtoMoment
{
    public required Month Month { get; init; }
}