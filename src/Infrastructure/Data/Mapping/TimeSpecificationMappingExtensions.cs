using Domain.Entities;
using Infrastructure.Data.DbEntities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;


public static partial class MappingExtensions
{
    //From DB
    internal static partial TimeSpecificationDto ToTimeSpecificationInner(this DbTimeSpecification dbTimeSpecification);
    internal static partial TimeSpecificationDtoMoment ToTimeSpecificationMomentInner(this DbTimeSpecificationMoment dbTimeSpecificationMoment);
    public static partial TimeSpecificationDtoPeriod ToTimeSpecificationPeriod(this DbTimeSpecificationPeriod dbTimeSpecificationPeriod);
    public static partial TimeSpecificationDtoDate ToTimeSpecificationDate(this DbTimeSpecificationDate dbTimeSpecificationDate);
    public static partial TimeSpecificationDtoDateTime ToTimeSpecificationDateTime(this DbTimeSpecificationDateTime dbTimeSpecificationDateTime);
    public static partial TimeSpecificationDtoMonth ToTimeSpecificationMonth(this DbTimeSpecificationMonth dbTimeSpecificationMonth);

    [UserMapping(Default = true)]
    public static TimeSpecificationDto ToTimeSpecification(this DbTimeSpecification dbTimeSpecification) =>
        dbTimeSpecification switch
        {
            DbTimeSpecificationPeriod dbTimeSpecificationPeriod =>
                dbTimeSpecificationPeriod.ToTimeSpecificationPeriod(),
            DbTimeSpecificationMoment dbTimeSpecificationMoment =>
                dbTimeSpecificationMoment.ToTimeSpecificationMoment(),
            _ => dbTimeSpecification.ToTimeSpecificationInner()
        };

    [UserMapping(Default = true)]
    public static TimeSpecificationDtoMoment ToTimeSpecificationMoment(this DbTimeSpecificationMoment dbTimeSpecificationMoment) =>
        dbTimeSpecificationMoment switch
        {
            DbTimeSpecificationDate dbTimeSpecificationDate => dbTimeSpecificationDate.ToTimeSpecificationDate(),
            DbTimeSpecificationDateTime dbTimeSpecificationDateTime => dbTimeSpecificationDateTime
                .ToTimeSpecificationDateTime(),
            DbTimeSpecificationMonth dbTimeSpecificationMonth => dbTimeSpecificationMonth.ToTimeSpecificationMonth(),
            _ => dbTimeSpecificationMoment.ToTimeSpecificationMomentInner()
        };

    // To DB
    internal static partial DbTimeSpecification ToDbTimeSpecificationInner(this TimeSpecificationDto timeSpecificationDto);
    internal static partial DbTimeSpecificationMoment ToDbTimeSpecificationMomentInner(this TimeSpecificationDtoMoment timeSpecificationDtoMoment);

    public static partial DbTimeSpecificationPeriod ToDbTimeSpecificationPeriod(this TimeSpecificationDtoPeriod timeSpecificationDtoPeriod);
    
    internal static DbTimeSpecificationPeriodStartConnection ToDbTimeSpecificationPeriodStartConnection(this TimeSpecificationDtoMoment dtoMoment) => new()
    {
        MomentId = dtoMoment.EntityId
    };
    internal static TimeSpecificationDtoMoment ToTimeSpecificationMoment(this DbTimeSpecificationPeriodStartConnection dbTimeSpecificationPeriodStartConnection) => dbTimeSpecificationPeriodStartConnection.Moment!.ToTimeSpecificationMoment();
    
    internal static DbTimeSpecificationPeriodEndConnection ToDbTimeSpecificationPeriodEndConnection(this TimeSpecificationDtoMoment dtoMoment) => new()
    {
        MomentId = dtoMoment.EntityId
    };
    internal static TimeSpecificationDtoMoment ToTimeSpecificationMoment(this DbTimeSpecificationPeriodEndConnection dbTimeSpecificationPeriodStartConnection) => dbTimeSpecificationPeriodStartConnection.Moment!.ToTimeSpecificationMoment();

    
    public static partial DbTimeSpecificationDate ToDbTimeSpecificationDate(this TimeSpecificationDtoDate timeSpecificationDtoDate);
    public static partial DbTimeSpecificationDateTime ToDbTimeSpecificationDateTime(this TimeSpecificationDtoDateTime timeSpecificationDtoDateTime);
    public static partial DbTimeSpecificationMonth ToDbTimeSpecificationMonth(this TimeSpecificationDtoMonth timeSpecificationDtoMonth);
    [UserMapping(Default = true)]

    public static DbTimeSpecification ToDbTimeSpecification(this TimeSpecificationDto timeSpecificationDto) =>
        timeSpecificationDto switch
        {
            TimeSpecificationDtoPeriod timeSpecificationPeriod => timeSpecificationPeriod.ToDbTimeSpecificationPeriod(),
            TimeSpecificationDtoMoment timeSpecificationMoment => timeSpecificationMoment.ToDbTimeSpecificationMoment(),
            _ => timeSpecificationDto.ToDbTimeSpecificationInner()
        };

    [UserMapping(Default = true)]
    public static DbTimeSpecificationMoment ToDbTimeSpecificationMoment(this TimeSpecificationDtoMoment timeSpecificationDtoMoment) =>
        timeSpecificationDtoMoment switch
        {
            TimeSpecificationDtoDate timeSpecificationDate => timeSpecificationDate.ToDbTimeSpecificationDate(),
            TimeSpecificationDtoDateTime timeSpecificationDateTime => timeSpecificationDateTime
                .ToDbTimeSpecificationDateTime(),
            TimeSpecificationDtoMonth timeSpecificationMonth => timeSpecificationMonth.ToDbTimeSpecificationMonth(),
            _ => timeSpecificationDtoMoment.ToDbTimeSpecificationMomentInner()
        };
}