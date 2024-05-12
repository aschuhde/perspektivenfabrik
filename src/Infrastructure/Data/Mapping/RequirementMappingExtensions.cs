using Domain.Entities;
using Infrastructure.Data.DbEntities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;


public static partial class MappingExtensions
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
    [MapperIgnoreTarget(nameof(DbRequirementSpecification.TimeSpecifications))]
    [MapperIgnoreTarget(nameof(DbRequirementSpecification.QuantitySpecification))]
    internal static partial DbRequirementSpecification ToDbRequirementSpecificationInnerInner(this RequirementSpecification requirementSpecification);
    
    private static DbRequirementSpecification ToDbRequirementSpecificationInner(this RequirementSpecification requirementSpecification)
    {
        var r = requirementSpecification.ToDbRequirementSpecificationInnerInner();
        SetTimeAndQuantitySpecification(r, requirementSpecification);
        return r;
    }

    private static void SetTimeAndQuantitySpecification(DbRequirementSpecification dbRequirementSpecification,
        RequirementSpecification requirementSpecification)
    {
        dbRequirementSpecification.TimeSpecifications = MappingTools.MapArray(requirementSpecification.TimeSpecifications, x =>
            new DbTimeSpecificationRequirementConnection()
            {
                RequirementSpecificationId = dbRequirementSpecification.EntityId,
                TimeSpecificationId = x.EntityId
            });
        dbRequirementSpecification.QuantitySpecification = new DbQuantitySpecificationRequirementConnection()
        {
            RequirementSpecificationId = dbRequirementSpecification.EntityId,
            QuantitySpecificationId = requirementSpecification.QuantitySpecification.EntityId
        };
    }
    
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
    
    [MapperIgnoreTarget(nameof(DbRequirementSpecificationPerson.SkillSpecifications))]
    [MapperIgnoreTarget(nameof(DbRequirementSpecificationPerson.WorkAmountSpecifications))]
    [MapperIgnoreTarget(nameof(DbRequirementSpecification.TimeSpecifications))]
    [MapperIgnoreTarget(nameof(DbRequirementSpecification.QuantitySpecification))]
    internal static partial DbRequirementSpecificationPerson ToDbRequirementSpecificationPersonInner(this RequirementSpecificationPerson requirementSpecificationPerson);

    [UserMapping(Default = true)]
    public static DbRequirementSpecificationPerson ToDbRequirementSpecificationPerson(
        this RequirementSpecificationPerson requirementSpecificationPerson)
    {
        var r = requirementSpecificationPerson.ToDbRequirementSpecificationPersonInner();
        SetTimeAndQuantitySpecification(r, requirementSpecificationPerson);
        r.SkillSpecifications = MappingTools.MapArray(requirementSpecificationPerson.TimeSpecifications, x =>
            new DbSkillSpecificationRequirementConnection()
            {
                RequirementSpecificationId = r.EntityId,
                SkillSpecificationId = x.EntityId
            });
        r.WorkAmountSpecifications = MappingTools.MapArray(requirementSpecificationPerson.WorkAmountSpecifications, x =>
            new DbWorkAmountSpecificationRequirementConnection()
            {
                RequirementSpecificationId = r.EntityId,
                WorkAmountSpecificationId = x.EntityId
            });
        return r;
    }
    
    [MapperIgnoreTarget(nameof(DbRequirementSpecificationMaterial.MaterialSpecifications))]
    [MapperIgnoreTarget(nameof(DbRequirementSpecification.TimeSpecifications))]
    [MapperIgnoreTarget(nameof(DbRequirementSpecification.QuantitySpecification))]
    internal static partial DbRequirementSpecificationMaterial ToDbRequirementSpecificationMaterialInner(this RequirementSpecificationMaterial requirementSpecificationMaterial);
    
    [UserMapping(Default = true)]
    public static DbRequirementSpecificationMaterial ToDbRequirementSpecificationMaterial(
        this RequirementSpecificationMaterial requirementSpecificationMaterial)
    {
        var r = requirementSpecificationMaterial.ToDbRequirementSpecificationMaterialInner();
        SetTimeAndQuantitySpecification(r, requirementSpecificationMaterial);
        r.MaterialSpecifications = MappingTools.MapArray(requirementSpecificationMaterial.TimeSpecifications, x =>
            new DbMaterialSpecificationRequirementConnection()
            {
                RequirementSpecificationId = r.EntityId,
                MaterialSpecificationId = x.EntityId
            });
        return r;
    }
    
    [MapperIgnoreTarget(nameof(DbRequirementSpecificationMoney.MaterialSpecifications))]
    [MapperIgnoreTarget(nameof(DbRequirementSpecification.TimeSpecifications))]
    [MapperIgnoreTarget(nameof(DbRequirementSpecification.QuantitySpecification))]
    internal static partial DbRequirementSpecificationMoney ToDbRequirementSpecificationMoneyInner(this RequirementSpecificationMoney requirementSpecificationMoney);
    
    [UserMapping(Default = true)]
    public static DbRequirementSpecificationMoney ToDbRequirementSpecificationMoney(
        this RequirementSpecificationMoney requirementSpecificationMoney)
    {
        var r = requirementSpecificationMoney.ToDbRequirementSpecificationMoneyInner();
        SetTimeAndQuantitySpecification(r, requirementSpecificationMoney);
        r.MaterialSpecifications = MappingTools.MapArray(requirementSpecificationMoney.TimeSpecifications, x =>
            new DbMaterialSpecificationRequirementConnection()
            {
                RequirementSpecificationId = r.EntityId,
                MaterialSpecificationId = x.EntityId
            });
        return r;
    }
   
    
}