using Domain.Entities;
using Infrastructure.Data.DbEntities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;


public static partial class MappingExtensions
{
    [MapperIgnoreTarget(nameof(QuantitySpecificationDto.ValueTranslations))]
    public static partial QuantitySpecificationDto ToQuantitySpecification(this DbQuantitySpecification dbQuantitySpecification);
    [MapperIgnoreSource(nameof(QuantitySpecificationDto.ValueTranslations))]
    public static partial DbQuantitySpecification ToDbQuantitySpecification(this QuantitySpecificationDto quantitySpecificationDto);
}