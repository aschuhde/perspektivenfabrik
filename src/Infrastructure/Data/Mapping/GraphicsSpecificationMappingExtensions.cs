using Domain.Entities;
using Infrastructure.Data.DbEntities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;


public static partial class MappingExtensions
{
    public static partial GraphicsSpecificationDto ToGraphicsSpecification(this DbGraphicsSpecification dbGraphicsSpecification);
    
    public static partial DbGraphicsSpecification ToDbGraphicsSpecification(this GraphicsSpecificationDto graphicsSpecificationDto);
}