using Domain.Entities;
using Infrastructure.Data.DbEntities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;


public static partial class MappingExtensions
{
    [MapperIgnoreTarget(nameof(MaterialSpecificationDto.NameTranslations))]
    [MapperIgnoreTarget(nameof(MaterialSpecificationDto.AmountValueTranslations))]
    public static partial MaterialSpecificationDto ToMaterialSpecification(this DbMaterialSpecification dbMaterialSpecification);
    
    [MapperIgnoreSource(nameof(MaterialSpecificationDto.NameTranslations))]
    [MapperIgnoreSource(nameof(MaterialSpecificationDto.AmountValueTranslations))]
    public static partial DbMaterialSpecification ToDbMaterialSpecification(this MaterialSpecificationDto materialSpecificationDto);
}