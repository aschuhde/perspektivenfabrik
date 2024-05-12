using Domain.Entities;
using Infrastructure.Data.DbEntities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;

[Mapper]
public static partial class QuantitySpecificationMappingExtensions
{
    public static partial QuantitySpecification ToQuantitySpecification(this DbQuantitySpecification dbQuantitySpecification);
    public static partial DbQuantitySpecification ToDbQuantitySpecification(this QuantitySpecification quantitySpecification);
}