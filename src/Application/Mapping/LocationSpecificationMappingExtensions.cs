using Application.Models.ApiModels;
using Domain.Entities;
using Domain.Enums;
using Riok.Mapperly.Abstractions;

namespace Application.Mapping;


public static partial class ApiMappingExtensions
{
    internal static partial LocationSpecificationDto ToLocationSpecificationInner(this ApiLocationSpecification apiLocationSpecification);
    public static partial LocationSpecificationDtoRemote ToLocationSpecificationRemote(this ApiLocationSpecificationRemote apiLocationSpecificationRemote);
    public static partial LocationSpecificationDtoRegion ToLocationSpecificationRegion(this ApiLocationSpecificationRegion apiLocationSpecificationRegion);
    public static partial LocationSpecificationDtoCoordinates ToLocationSpecificationCoordinates(this ApiLocationSpecificationCoordinates apiLocationSpecificationCoordinates);
    public static partial LocationSpecificationDtoAddress ToLocationSpecificationAddress(this ApiLocationSpecificationAddress apiLocationSpecificationAddress);
    public static partial LocationSpecificationDtoName ToLocationSpecificationName(this ApiLocationSpecificationName apiLocationSpecificationName);
    public static partial LocationSpecificationDtoEntireProvince ToLocationSpecificationEntireProvince(this ApiLocationSpecificationEntireProvince apiLocationSpecificationEntireProvince);

    [UserMapping(Default = true)]
    public static LocationSpecificationDto ToLocationSpecification(this ApiLocationSpecification apiLocationSpecification) =>
        apiLocationSpecification switch
        {
            ApiLocationSpecificationRemote apiLocationSpecificationRemote => apiLocationSpecificationRemote
                .ToLocationSpecificationRemote(),
            ApiLocationSpecificationRegion apiLocationSpecificationRegion => apiLocationSpecificationRegion
                .ToLocationSpecificationRegion(),
            ApiLocationSpecificationCoordinates apiLocationSpecificationCoordinates => apiLocationSpecificationCoordinates
                .ToLocationSpecificationCoordinates(),
            ApiLocationSpecificationAddress apiLocationSpecificationAddress => apiLocationSpecificationAddress
                .ToLocationSpecificationAddress(),
            ApiLocationSpecificationName apiLocationSpecificationName => apiLocationSpecificationName
                .ToLocationSpecificationName(),
            ApiLocationSpecificationEntireProvince apiLocationSpecificationEntireProvince => apiLocationSpecificationEntireProvince
                .ToLocationSpecificationEntireProvince(),
            _ => apiLocationSpecification.ToLocationSpecificationInner()
        };

    internal static partial ApiLocationSpecification ToApiLocationSpecificationInner(this LocationSpecificationDto locationSpecificationDto);
    public static partial ApiLocationSpecificationRemote ToApiLocationSpecificationRemote(this LocationSpecificationDtoRemote locationSpecificationDtoRemote);
    public static partial ApiLocationSpecificationRegion ToApiLocationSpecificationRegion(this LocationSpecificationDtoRegion locationSpecificationDtoRegion);
    public static partial ApiLocationSpecificationCoordinates ToApiLocationSpecificationCoordinates(this LocationSpecificationDtoCoordinates locationSpecificationDtoCoordinates);
    public static partial ApiLocationSpecificationAddress ToApiLocationSpecificationAddress(this LocationSpecificationDtoAddress locationSpecificationDtoAddress);
    public static partial ApiLocationSpecificationName ToApiLocationSpecificationName(this LocationSpecificationDtoName locationSpecificationDtoName);
    public static partial ApiLocationSpecificationEntireProvince ToApiLocationSpecificationEntireProvince(this LocationSpecificationDtoEntireProvince locationSpecificationDtoEntireProvince);
    [UserMapping(Default = true)]
    public static ApiLocationSpecification ToApiLocationSpecification(this LocationSpecificationDto locationSpecificationDto) =>
        locationSpecificationDto switch
        {
            LocationSpecificationDtoRemote locationSpecificationRemote => locationSpecificationRemote
                .ToApiLocationSpecificationRemote(),
            LocationSpecificationDtoRegion locationSpecificationRegion => locationSpecificationRegion
                .ToApiLocationSpecificationRegion(),
            LocationSpecificationDtoCoordinates locationSpecificationCoordinates => locationSpecificationCoordinates
                .ToApiLocationSpecificationCoordinates(),
            LocationSpecificationDtoAddress locationSpecificationAddress => locationSpecificationAddress
                .ToApiLocationSpecificationAddress(),
            LocationSpecificationDtoName locationSpecificationName => locationSpecificationName
                .ToApiLocationSpecificationName(),
            LocationSpecificationDtoEntireProvince locationSpecificationEntireProvince => locationSpecificationEntireProvince
                .ToApiLocationSpecificationEntireProvince(),
            _ => locationSpecificationDto.ToApiLocationSpecificationInner()
        };
}