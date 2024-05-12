using Domain.Entities;
using Infrastructure.Data.DbEntities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;


public static partial class MappingExtensions
{
    public static partial QuantitySpecification ToQuantitySpecification(this DbQuantitySpecification dbQuantitySpecification);
    public static partial DbQuantitySpecification ToDbQuantitySpecification(this QuantitySpecification quantitySpecification);
}