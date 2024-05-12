using Domain.Entities;
using Infrastructure.Data.DbEntities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;

[Mapper]
public static partial class GraphicsSpecificationMappingExtensions
{
    public static partial GraphicsSpecification ToGraphicsSpecification(this DbGraphicsSpecification dbGraphicsSpecification);
    
    public static partial DbGraphicsSpecification ToDbGraphicsSpecification(this GraphicsSpecification graphicsSpecification);
}