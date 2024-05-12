using Domain.Entities;
using Infrastructure.Data.DbEntities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;


public static partial class MappingExtensions
{
    internal static partial LocationSpecification ToLocationSpecificationInner(this DbLocationSpecification dbLocationSpecification);
    public static partial LocationSpecificationRemote ToLocationSpecificationRemote(this DbLocationSpecificationRemote dbLocationSpecificationRemote);
    public static partial LocationSpecificationRegion ToLocationSpecificationRegion(this DbLocationSpecificationRegion dbLocationSpecificationRegion);
    public static partial LocationSpecificationCoordinates ToLocationSpecificationCoordinates(this DbLocationSpecificationCoordinates dbLocationSpecificationCoordinates);
    public static partial LocationSpecificationAddress ToLocationSpecificationAddress(this DbLocationSpecificationAddress dbLocationSpecificationAddress);

    [UserMapping(Default = true)]
    public static LocationSpecification ToLocationSpecification(this DbLocationSpecification dbLocationSpecification) =>
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
            _ => dbLocationSpecification.ToLocationSpecificationInner()
        };

    internal static partial DbLocationSpecification ToDbLocationSpecificationInner(this LocationSpecification locationSpecification);
    public static partial DbLocationSpecificationRemote ToDbLocationSpecificationRemote(this LocationSpecificationRemote locationSpecificationRemote);
    public static partial DbLocationSpecificationRegion ToDbLocationSpecificationRegion(this LocationSpecificationRegion locationSpecificationRegion);
    public static partial DbLocationSpecificationCoordinates ToDbLocationSpecificationCoordinates(this LocationSpecificationCoordinates locationSpecificationCoordinates);
    public static partial DbLocationSpecificationAddress ToDbLocationSpecificationAddress(this LocationSpecificationAddress locationSpecificationAddress);
    [UserMapping(Default = true)]
    public static DbLocationSpecification ToDbLocationSpecification(this LocationSpecification locationSpecification) =>
        locationSpecification switch
        {
            LocationSpecificationRemote locationSpecificationRemote => locationSpecificationRemote
                .ToDbLocationSpecificationRemote(),
            LocationSpecificationRegion locationSpecificationRegion => locationSpecificationRegion
                .ToDbLocationSpecificationRegion(),
            LocationSpecificationCoordinates locationSpecificationCoordinates => locationSpecificationCoordinates
                .ToDbLocationSpecificationCoordinates(),
            LocationSpecificationAddress locationSpecificationAddress => locationSpecificationAddress
                .ToDbLocationSpecificationAddress(),
            _ => locationSpecification.ToDbLocationSpecificationInner()
        };
}