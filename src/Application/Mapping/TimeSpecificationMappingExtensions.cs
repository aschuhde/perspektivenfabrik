using Application.Models;
using Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Application.Mapping;


public static partial class ApiMappingExtensions
{
    //From Api
    internal static partial TimeSpecificationDto ToTimeSpecificationInner(this ApiTimeSpecification apiTimeSpecification);
    internal static partial TimeSpecificationDtoMoment ToTimeSpecificationMomentInner(this ApiTimeSpecificationMoment apiTimeSpecificationMoment);
    public static partial TimeSpecificationDtoPeriod ToTimeSpecificationPeriod(this ApiTimeSpecificationPeriod apiTimeSpecificationPeriod);
    public static partial TimeSpecificationDtoDate ToTimeSpecificationDate(this ApiTimeSpecificationDate apiTimeSpecificationDate);
    public static partial TimeSpecificationDtoDateTime ToTimeSpecificationDateTime(this ApiTimeSpecificationDateTime apiTimeSpecificationDateTime);
    public static partial TimeSpecificationDtoMonth ToTimeSpecificationMonth(this ApiTimeSpecificationMonth apiTimeSpecificationMonth);

    [UserMapping(Default = true)]
    public static TimeSpecificationDto ToTimeSpecification(this ApiTimeSpecification apiTimeSpecification) =>
        apiTimeSpecification switch
        {
            ApiTimeSpecificationPeriod apiTimeSpecificationPeriod =>
                apiTimeSpecificationPeriod.ToTimeSpecificationPeriod(),
            ApiTimeSpecificationMoment apiTimeSpecificationMoment =>
                apiTimeSpecificationMoment.ToTimeSpecificationMoment(),
            _ => apiTimeSpecification.ToTimeSpecificationInner()
        };

    [UserMapping(Default = true)]
    public static TimeSpecificationDtoMoment ToTimeSpecificationMoment(this ApiTimeSpecificationMoment apiTimeSpecificationMoment) =>
        apiTimeSpecificationMoment switch
        {
            ApiTimeSpecificationDate apiTimeSpecificationDate => apiTimeSpecificationDate.ToTimeSpecificationDate(),
            ApiTimeSpecificationDateTime apiTimeSpecificationDateTime => apiTimeSpecificationDateTime
                .ToTimeSpecificationDateTime(),
            ApiTimeSpecificationMonth apiTimeSpecificationMonth => apiTimeSpecificationMonth.ToTimeSpecificationMonth(),
            _ => apiTimeSpecificationMoment.ToTimeSpecificationMomentInner()
        };

    // To Api
    internal static partial ApiTimeSpecification ToApiTimeSpecificationInner(this TimeSpecificationDto timeSpecificationDto);
    internal static partial ApiTimeSpecificationMoment ToApiTimeSpecificationMomentInner(this TimeSpecificationDtoMoment timeSpecificationDtoMoment);

    public static partial ApiTimeSpecificationPeriod ToApiTimeSpecificationPeriod(this TimeSpecificationDtoPeriod timeSpecificationDtoPeriod);
    
    public static partial ApiTimeSpecificationDate ToApiTimeSpecificationDate(this TimeSpecificationDtoDate timeSpecificationDtoDate);
    public static partial ApiTimeSpecificationDateTime ToApiTimeSpecificationDateTime(this TimeSpecificationDtoDateTime timeSpecificationDtoDateTime);
    public static partial ApiTimeSpecificationMonth ToApiTimeSpecificationMonth(this TimeSpecificationDtoMonth timeSpecificationDtoMonth);
    [UserMapping(Default = true)]

    public static ApiTimeSpecification ToApiTimeSpecification(this TimeSpecificationDto timeSpecificationDto) =>
        timeSpecificationDto switch
        {
            TimeSpecificationDtoPeriod timeSpecificationPeriod => timeSpecificationPeriod.ToApiTimeSpecificationPeriod(),
            TimeSpecificationDtoMoment timeSpecificationMoment => timeSpecificationMoment.ToApiTimeSpecificationMoment(),
            _ => timeSpecificationDto.ToApiTimeSpecificationInner()
        };

    [UserMapping(Default = true)]
    public static ApiTimeSpecificationMoment ToApiTimeSpecificationMoment(this TimeSpecificationDtoMoment timeSpecificationDtoMoment) =>
        timeSpecificationDtoMoment switch
        {
            TimeSpecificationDtoDate timeSpecificationDate => timeSpecificationDate.ToApiTimeSpecificationDate(),
            TimeSpecificationDtoDateTime timeSpecificationDateTime => timeSpecificationDateTime
                .ToApiTimeSpecificationDateTime(),
            TimeSpecificationDtoMonth timeSpecificationMonth => timeSpecificationMonth.ToApiTimeSpecificationMonth(),
            _ => timeSpecificationDtoMoment.ToApiTimeSpecificationMomentInner()
        };
}