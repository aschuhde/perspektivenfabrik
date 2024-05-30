using Application.Models;
using Application.Models.ApiModels;
using Domain.Entities;

namespace Application.Mapping;


public static partial class ApiMappingExtensions
{
    public static partial DescriptionSpecificationDto ToDescriptionSpecification(this ApiDescriptionSpecification apiDescriptionSpecification);
    
    public static partial ApiDescriptionSpecification ToApiDescriptionSpecification(this DescriptionSpecificationDto descriptionSpecificationDto);
}