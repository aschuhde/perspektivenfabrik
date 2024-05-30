using Application.Models;
using Application.Models.ApiModels;
using Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Application.Mapping;


public static partial class ApiMappingExtensions
{
    // From Api
    internal static partial RequirementSpecificationDto ToRequirementSpecificationInner(this ApiRequirementSpecification apiRequirementSpecification);
    public static partial RequirementSpecificationDtoPerson ToRequirementSpecificationPerson(this ApiRequirementSpecificationPerson apiRequirementSpecificationPerson);
    public static partial RequirementSpecificationDtoMaterial ToRequirementSpecificationMaterial(this ApiRequirementSpecificationMaterial apiRequirementSpecificationMaterial);
    public static partial RequirementSpecificationDtoMoney ToRequirementSpecificationMoney(this ApiRequirementSpecificationMoney apiRequirementSpecificationMoney);

    [UserMapping(Default = true)]
    public static RequirementSpecificationDto ToRequirementSpecification(
        this ApiRequirementSpecification apiRequirementSpecification) =>
        apiRequirementSpecification switch
        {
            ApiRequirementSpecificationPerson apiRequirementSpecificationPerson => apiRequirementSpecificationPerson.ToRequirementSpecificationPerson(),
            ApiRequirementSpecificationMaterial apiRequirementSpecificationMaterial => apiRequirementSpecificationMaterial.ToRequirementSpecificationMaterial(),
            ApiRequirementSpecificationMoney apiRequirementSpecificationMoney => apiRequirementSpecificationMoney.ToRequirementSpecificationMoney(),
            _ => apiRequirementSpecification.ToRequirementSpecificationInner()
        };
    
    // To Api
    internal static partial ApiRequirementSpecification ToApiRequirementSpecificationInner(this RequirementSpecificationDto requirementSpecificationDto);
    
    
    [UserMapping(Default = true)]
    public static ApiRequirementSpecification ToApiRequirementSpecification(
        this RequirementSpecificationDto requirementSpecificationDto) =>
        requirementSpecificationDto switch
        {
            RequirementSpecificationDtoPerson requirementSpecificationPerson => requirementSpecificationPerson.ToApiRequirementSpecificationPerson(),
            RequirementSpecificationDtoMaterial requirementSpecificationMaterial => requirementSpecificationMaterial.ToApiRequirementSpecificationMaterial(),
            RequirementSpecificationDtoMoney requirementSpecificationMoney => requirementSpecificationMoney.ToApiRequirementSpecificationMoney(),
            _ => requirementSpecificationDto.ToApiRequirementSpecificationInner()
        };
    
    public static partial ApiRequirementSpecificationPerson ToApiRequirementSpecificationPerson(this RequirementSpecificationDtoPerson requirementSpecificationDtoPerson);
    
    public static partial ApiRequirementSpecificationMaterial ToApiRequirementSpecificationMaterial(this RequirementSpecificationDtoMaterial requirementSpecificationDtoMaterial);
    
    public static partial ApiRequirementSpecificationMoney ToApiRequirementSpecificationMoney(this RequirementSpecificationDtoMoney requirementSpecificationDtoMoney);
   
    
}