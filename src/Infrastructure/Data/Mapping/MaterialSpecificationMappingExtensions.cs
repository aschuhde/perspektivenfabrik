using Domain.Entities;
using Infrastructure.Data.DbEntities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;


public static partial class MappingExtensions
{
    public static partial MaterialSpecificationDto ToMaterialSpecification(this DbMaterialSpecification dbMaterialSpecification);
    
    public static partial DbMaterialSpecification ToDbMaterialSpecification(this MaterialSpecificationDto materialSpecificationDto);
}