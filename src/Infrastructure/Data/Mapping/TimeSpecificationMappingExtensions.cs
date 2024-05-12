using Domain.Entities;
using Infrastructure.Data.DbEntities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;

[Mapper]
public static partial class TimeSpecificationMappingExtensions
{
    //From DB
    internal static partial TimeSpecification ToTimeSpecificationInner(this DbTimeSpecification dbTimeSpecification);
    internal static partial TimeSpecificationMoment ToTimeSpecificationMomentInner(this DbTimeSpecificationMoment dbTimeSpecificationMoment);
    public static partial TimeSpecificationPeriod ToTimeSpecificationPeriod(this DbTimeSpecificationPeriod dbTimeSpecificationPeriod);
    public static partial TimeSpecificationDate ToTimeSpecificationDate(this DbTimeSpecificationDate dbTimeSpecificationDate);
    public static partial TimeSpecificationDateTime ToTimeSpecificationDateTime(this DbTimeSpecificationDateTime dbTimeSpecificationDateTime);
    public static partial TimeSpecificationMonth ToTimeSpecificationMonth(this DbTimeSpecificationMonth dbTimeSpecificationMonth);

    [UserMapping(Default = true)]
    public static TimeSpecification ToTimeSpecification(this DbTimeSpecification dbTimeSpecification) =>
        dbTimeSpecification switch
        {
            DbTimeSpecificationPeriod dbTimeSpecificationPeriod =>
                dbTimeSpecificationPeriod.ToTimeSpecificationPeriod(),
            DbTimeSpecificationMoment dbTimeSpecificationMoment =>
                dbTimeSpecificationMoment.ToTimeSpecificationMoment(),
            _ => dbTimeSpecification.ToTimeSpecificationInner()
        };

    [UserMapping(Default = true)]
    public static TimeSpecificationMoment ToTimeSpecificationMoment(this DbTimeSpecificationMoment dbTimeSpecificationMoment) =>
        dbTimeSpecificationMoment switch
        {
            DbTimeSpecificationDate dbTimeSpecificationDate => dbTimeSpecificationDate.ToTimeSpecificationDate(),
            DbTimeSpecificationDateTime dbTimeSpecificationDateTime => dbTimeSpecificationDateTime
                .ToTimeSpecificationDateTime(),
            DbTimeSpecificationMonth dbTimeSpecificationMonth => dbTimeSpecificationMonth.ToTimeSpecificationMonth(),
            _ => dbTimeSpecificationMoment.ToTimeSpecificationMomentInner()
        };

    // To DB
    internal static partial DbTimeSpecification ToDbTimeSpecificationInner(this TimeSpecification timeSpecification);
    internal static partial DbTimeSpecificationMoment ToDbTimeSpecificationMomentInner(this TimeSpecificationMoment timeSpecificationMoment);
    public static partial DbTimeSpecificationPeriod ToDbTimeSpecificationPeriod(this TimeSpecificationPeriod timeSpecificationPeriod);
    public static partial DbTimeSpecificationDate ToDbTimeSpecificationDate(this TimeSpecificationDate timeSpecificationDate);
    public static partial DbTimeSpecificationDateTime ToDbTimeSpecificationDateTime(this TimeSpecificationDateTime timeSpecificationDateTime);
    public static partial DbTimeSpecificationMonth ToDbTimeSpecificationMonth(this TimeSpecificationMonth timeSpecificationMonth);
    [UserMapping(Default = true)]

    public static DbTimeSpecification ToDbTimeSpecification(this TimeSpecification timeSpecification) =>
        timeSpecification switch
        {
            TimeSpecificationPeriod timeSpecificationPeriod => timeSpecificationPeriod.ToDbTimeSpecificationPeriod(),
            TimeSpecificationMoment timeSpecificationMoment => timeSpecificationMoment.ToDbTimeSpecificationMoment(),
            _ => timeSpecification.ToDbTimeSpecificationInner()
        };

    [UserMapping(Default = true)]
    public static DbTimeSpecificationMoment ToDbTimeSpecificationMoment(this TimeSpecificationMoment timeSpecificationMoment) =>
        timeSpecificationMoment switch
        {
            TimeSpecificationDate timeSpecificationDate => timeSpecificationDate.ToDbTimeSpecificationDate(),
            TimeSpecificationDateTime timeSpecificationDateTime => timeSpecificationDateTime
                .ToDbTimeSpecificationDateTime(),
            TimeSpecificationMonth timeSpecificationMonth => timeSpecificationMonth.ToDbTimeSpecificationMonth(),
            _ => timeSpecificationMoment.ToDbTimeSpecificationMomentInner()
        };
}