using Application.Models;
using Domain.Entities;

namespace Application.Mapping;


public static partial class ApiMappingExtensions
{
    public static partial GraphicsSpecificationDto ToGraphicsSpecification(this ApiGraphicsSpecification apiGraphicsSpecification);
    
    public static partial ApiGraphicsSpecification ToApiGraphicsSpecification(this GraphicsSpecificationDto graphicsSpecificationDto);
}