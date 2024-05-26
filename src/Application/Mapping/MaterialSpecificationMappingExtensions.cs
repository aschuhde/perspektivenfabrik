using Application.Models;
using Domain.Entities;

namespace Application.Mapping;


public static partial class ApiMappingExtensions
{
    public static partial MaterialSpecificationDto ToMaterialSpecification(this ApiMaterialSpecification apiMaterialSpecification);
    
    public static partial ApiMaterialSpecification ToApiMaterialSpecification(this MaterialSpecificationDto materialSpecificationDto);
}