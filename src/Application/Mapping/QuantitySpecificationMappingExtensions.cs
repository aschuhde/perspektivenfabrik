using Application.Models;
using Domain.Entities;

namespace Application.Mapping;


public static partial class ApiMappingExtensions
{
    public static partial QuantitySpecificationDto ToQuantitySpecification(this ApiQuantitySpecification apiQuantitySpecification);
    public static partial ApiQuantitySpecification ToApiQuantitySpecification(this QuantitySpecificationDto quantitySpecificationDto);
}