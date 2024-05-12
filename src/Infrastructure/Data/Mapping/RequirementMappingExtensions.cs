using Domain.Entities;
using Infrastructure.Data.DbEntities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;

[Mapper]
public static partial class RequirementMappingExtensions
{
    // To DB
    internal static partial RequirementSpecification ToRequirementSpecificationInner(this DbRequirementSpecification dbRequirementSpecification);
    public static partial RequirementSpecificationPerson ToRequirementSpecificationPerson(this DbRequirementSpecificationPerson dbRequirementSpecificationPerson);
    public static partial RequirementSpecificationMaterial ToRequirementSpecificationMaterial(this DbRequirementSpecificationMaterial dbRequirementSpecificationMaterial);
    public static partial RequirementSpecificationMoney ToRequirementSpecificationMoney(this DbRequirementSpecificationMoney dbRequirementSpecificationMoney);

    [UserMapping(Default = true)]
    public static RequirementSpecification ToRequirementSpecification(
        this DbRequirementSpecification dbRequirementSpecification) =>
        dbRequirementSpecification switch
        {
            DbRequirementSpecificationPerson dbRequirementSpecificationPerson => dbRequirementSpecificationPerson.ToRequirementSpecificationPerson(),
            DbRequirementSpecificationMaterial dbRequirementSpecificationMaterial => dbRequirementSpecificationMaterial.ToRequirementSpecificationMaterial(),
            DbRequirementSpecificationMoney dbRequirementSpecificationMoney => dbRequirementSpecificationMoney.ToRequirementSpecificationMoney(),
            _ => dbRequirementSpecification.ToRequirementSpecificationInner()
        };
    
    // From DB
    internal static partial DbRequirementSpecification ToDbRequirementSpecificationInner(this RequirementSpecification requirementSpecification);
    public static partial DbRequirementSpecificationPerson ToDbRequirementSpecificationPerson(this RequirementSpecificationPerson requirementSpecificationPerson);
    public static partial DbRequirementSpecificationMaterial ToDbRequirementSpecificationMaterial(this RequirementSpecificationMaterial requirementSpecificationMaterial);
    public static partial DbRequirementSpecificationMoney ToDbRequirementSpecificationMoney(this RequirementSpecificationMoney requirementSpecificationMoney);
    [UserMapping(Default = true)]
    public static DbRequirementSpecification ToDbRequirementSpecification(
        this RequirementSpecification requirementSpecification) =>
        requirementSpecification switch
        {
            RequirementSpecificationPerson requirementSpecificationPerson => requirementSpecificationPerson.ToDbRequirementSpecificationPerson(),
            RequirementSpecificationMaterial requirementSpecificationMaterial => requirementSpecificationMaterial.ToDbRequirementSpecificationMaterial(),
            RequirementSpecificationMoney requirementSpecificationMoney => requirementSpecificationMoney.ToDbRequirementSpecificationMoney(),
            _ => requirementSpecification.ToDbRequirementSpecificationInner()
        };
}