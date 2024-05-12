using Domain.Entities;
using Infrastructure.Data.DbEntities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;

[Mapper]
public static partial class MaterialSpecificationMappingExtensions
{
    public static partial MaterialSpecification ToMaterialSpecification(this DbMaterialSpecification dbMaterialSpecification);
    
    public static partial DbMaterialSpecification ToDbMaterialSpecification(this MaterialSpecification materialSpecification);
}