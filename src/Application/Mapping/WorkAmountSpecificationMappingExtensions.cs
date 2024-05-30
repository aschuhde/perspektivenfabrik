using Application.Models;
using Application.Models.ApiModels;
using Domain.Entities;

namespace Application.Mapping;


public static partial class ApiMappingExtensions
{
    public static partial WorkAmountSpecificationDto ToWorkAmountSpecification(this ApiWorkAmountSpecification apiWorkAmountSpecification);
    
    public static partial ApiWorkAmountSpecification ToApiWorkAmountSpecification(this WorkAmountSpecificationDto workAmountSpecificationDto);
}