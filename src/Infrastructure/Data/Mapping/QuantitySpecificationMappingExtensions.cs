using Domain.Entities;
using Infrastructure.Data.DbEntities;

namespace Infrastructure.Data.Mapping;


public static partial class MappingExtensions
{
    public static partial QuantitySpecificationDto ToQuantitySpecification(this DbQuantitySpecification dbQuantitySpecification);
    public static partial DbQuantitySpecification ToDbQuantitySpecification(this QuantitySpecificationDto quantitySpecificationDto);
}