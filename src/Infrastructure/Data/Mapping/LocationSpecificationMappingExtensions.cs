using Domain.Entities;
using Infrastructure.Data.DbEntities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;


public static partial class MappingExtensions
{
    internal static partial LocationSpecificationDto ToLocationSpecificationInner(this DbLocationSpecification dbLocationSpecification);
    public static partial LocationSpecificationDtoRemote ToLocationSpecificationRemote(this DbLocationSpecificationRemote dbLocationSpecificationRemote);
    public static partial LocationSpecificationDtoRegion ToLocationSpecificationRegion(this DbLocationSpecificationRegion dbLocationSpecificationRegion);
    public static partial LocationSpecificationDtoCoordinates ToLocationSpecificationCoordinates(this DbLocationSpecificationCoordinates dbLocationSpecificationCoordinates);
    public static partial LocationSpecificationDtoAddress ToLocationSpecificationAddress(this DbLocationSpecificationAddress dbLocationSpecificationAddress);
    public static partial LocationSpecificationDtoName ToLocationSpecificationName(this DbLocationSpecificationName dbLocationSpecificationName);
    public static partial LocationSpecificationDtoEntireProvince ToLocationSpecificationEntireProvince(this DbLocationSpecificationEntireProvince dbLocationSpecificationEntireProvince);

    [UserMapping(Default = true)]
    public static LocationSpecificationDto ToLocationSpecification(this DbLocationSpecification dbLocationSpecification) =>
        dbLocationSpecification switch
        {
            DbLocationSpecificationRemote dbLocationSpecificationRemote => dbLocationSpecificationRemote
                .ToLocationSpecificationRemote(),
            DbLocationSpecificationRegion dbLocationSpecificationRegion => dbLocationSpecificationRegion
                .ToLocationSpecificationRegion(),
            DbLocationSpecificationCoordinates dbLocationSpecificationCoordinates => dbLocationSpecificationCoordinates
                .ToLocationSpecificationCoordinates(),
            DbLocationSpecificationAddress dbLocationSpecificationAddress => dbLocationSpecificationAddress
                .ToLocationSpecificationAddress(),
            DbLocationSpecificationName dbLocationSpecificationName => dbLocationSpecificationName
                .ToLocationSpecificationName(),
            DbLocationSpecificationEntireProvince dbLocationSpecificationEntireProvince => dbLocationSpecificationEntireProvince
                .ToLocationSpecificationEntireProvince(),
            _ => dbLocationSpecification.ToLocationSpecificationInner()
        };

    internal static partial DbLocationSpecification ToDbLocationSpecificationInner(this LocationSpecificationDto locationSpecificationDto);
    public static partial DbLocationSpecificationRemote ToDbLocationSpecificationRemote(this LocationSpecificationDtoRemote locationSpecificationDtoRemote);
    public static partial DbLocationSpecificationRegion ToDbLocationSpecificationRegion(this LocationSpecificationDtoRegion locationSpecificationDtoRegion);
    public static partial DbLocationSpecificationCoordinates ToDbLocationSpecificationCoordinates(this LocationSpecificationDtoCoordinates locationSpecificationDtoCoordinates);
    public static partial DbLocationSpecificationAddress ToDbLocationSpecificationAddress(this LocationSpecificationDtoAddress locationSpecificationDtoAddress);
    public static partial DbLocationSpecificationName ToDbLocationSpecificationName(this LocationSpecificationDtoName locationSpecificationDtoName);
    public static partial DbLocationSpecificationEntireProvince ToDbLocationSpecificationEntireProvince(this LocationSpecificationDtoEntireProvince locationSpecificationDtoEntireProvince);
    [UserMapping(Default = true)]
    public static DbLocationSpecification ToDbLocationSpecification(this LocationSpecificationDto locationSpecificationDto) =>
        locationSpecificationDto switch
        {
            LocationSpecificationDtoRemote locationSpecificationRemote => locationSpecificationRemote
                .ToDbLocationSpecificationRemote(),
            LocationSpecificationDtoRegion locationSpecificationRegion => locationSpecificationRegion
                .ToDbLocationSpecificationRegion(),
            LocationSpecificationDtoCoordinates locationSpecificationCoordinates => locationSpecificationCoordinates
                .ToDbLocationSpecificationCoordinates(),
            LocationSpecificationDtoAddress locationSpecificationAddress => locationSpecificationAddress
                .ToDbLocationSpecificationAddress(),
            LocationSpecificationDtoName locationSpecificationName => locationSpecificationName
                .ToDbLocationSpecificationName(),
            LocationSpecificationDtoEntireProvince locationSpecificationEntireProvince => locationSpecificationEntireProvince
                .ToDbLocationSpecificationEntireProvince(),
            _ => locationSpecificationDto.ToDbLocationSpecificationInner()
        };
}