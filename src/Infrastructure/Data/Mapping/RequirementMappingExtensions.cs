using Domain.Entities;
using Infrastructure.Data.DbEntities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;


public static partial class MappingExtensions
{
    // To DB
    internal static partial RequirementSpecificationDto ToRequirementSpecificationInner(this DbRequirementSpecification dbRequirementSpecification);
    public static partial RequirementSpecificationDtoPerson ToRequirementSpecificationPerson(this DbRequirementSpecificationPerson dbRequirementSpecificationPerson);
    public static partial RequirementSpecificationDtoMaterial ToRequirementSpecificationMaterial(this DbRequirementSpecificationMaterial dbRequirementSpecificationMaterial);
    public static partial RequirementSpecificationDtoMoney ToRequirementSpecificationMoney(this DbRequirementSpecificationMoney dbRequirementSpecificationMoney);

    [UserMapping(Default = true)]
    public static RequirementSpecificationDto ToRequirementSpecification(
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
    [MapperIgnoreSource(nameof(RequirementSpecificationDto.TimeSpecifications))]
    [MapperIgnoreTarget(nameof(DbRequirementSpecification.QuantitySpecification))]
    [MapperIgnoreSource(nameof(RequirementSpecificationDto.QuantitySpecification))]
    internal static partial DbRequirementSpecification ToDbRequirementSpecificationInnerInner(this RequirementSpecificationDto requirementSpecificationDto);
    
    private static DbRequirementSpecification ToDbRequirementSpecificationInner(this RequirementSpecificationDto requirementSpecificationDto)
    {
        var r = requirementSpecificationDto.ToDbRequirementSpecificationInnerInner();
        SetTimeAndQuantitySpecification(r, requirementSpecificationDto);
        return r;
    }

    private static void SetTimeAndQuantitySpecification(DbRequirementSpecification dbRequirementSpecification,
        RequirementSpecificationDto requirementSpecificationDto)
    {
        dbRequirementSpecification.TimeSpecifications = MappingTools.MapArrayToList(requirementSpecificationDto.TimeSpecifications, x =>
            new DbTimeSpecificationRequirementConnection()
            {
                RequirementSpecificationId = dbRequirementSpecification.EntityId,
                TimeSpecificationId = x.EntityId
            });
        dbRequirementSpecification.QuantitySpecification = new DbQuantitySpecificationRequirementConnection()
        {
            RequirementSpecificationId = dbRequirementSpecification.EntityId,
            QuantitySpecificationId = requirementSpecificationDto.QuantitySpecification.EntityId
        };
    }
    
    [UserMapping(Default = true)]
    public static DbRequirementSpecification ToDbRequirementSpecification(
        this RequirementSpecificationDto requirementSpecificationDto) =>
        requirementSpecificationDto switch
        {
            RequirementSpecificationDtoPerson requirementSpecificationPerson => requirementSpecificationPerson.ToDbRequirementSpecificationPerson(),
            RequirementSpecificationDtoMaterial requirementSpecificationMaterial => requirementSpecificationMaterial.ToDbRequirementSpecificationMaterial(),
            RequirementSpecificationDtoMoney requirementSpecificationMoney => requirementSpecificationMoney.ToDbRequirementSpecificationMoney(),
            _ => requirementSpecificationDto.ToDbRequirementSpecificationInner()
        };
    
    [MapperIgnoreTarget(nameof(DbRequirementSpecificationPerson.SkillSpecifications))]
    [MapperIgnoreSource(nameof(RequirementSpecificationDtoPerson.SkillSpecifications))]
    [MapperIgnoreTarget(nameof(DbRequirementSpecificationPerson.WorkAmountSpecifications))]
    [MapperIgnoreSource(nameof(RequirementSpecificationDtoPerson.WorkAmountSpecifications))]
    [MapperIgnoreTarget(nameof(DbRequirementSpecificationPerson.LocationSpecifications))]
    [MapperIgnoreSource(nameof(RequirementSpecificationDtoPerson.LocationSpecifications))]
    [MapperIgnoreTarget(nameof(DbRequirementSpecification.TimeSpecifications))]
    [MapperIgnoreSource(nameof(RequirementSpecificationDtoPerson.TimeSpecifications))]
    [MapperIgnoreTarget(nameof(DbRequirementSpecification.QuantitySpecification))]
    [MapperIgnoreSource(nameof(RequirementSpecificationDtoPerson.QuantitySpecification))]
    internal static partial DbRequirementSpecificationPerson ToDbRequirementSpecificationPersonInner(this RequirementSpecificationDtoPerson requirementSpecificationDtoPerson);

    [UserMapping(Default = true)]
    public static DbRequirementSpecificationPerson ToDbRequirementSpecificationPerson(
        this RequirementSpecificationDtoPerson requirementSpecificationDtoPerson)
    {
        var r = requirementSpecificationDtoPerson.ToDbRequirementSpecificationPersonInner();
        SetTimeAndQuantitySpecification(r, requirementSpecificationDtoPerson);
        r.SkillSpecifications = MappingTools.MapArrayToList(requirementSpecificationDtoPerson.SkillSpecifications, x =>
            new DbSkillSpecificationRequirementConnection()
            {
                RequirementSpecificationId = r.EntityId,
                SkillSpecificationId = x.EntityId
            });
        r.WorkAmountSpecifications = MappingTools.MapArrayToList(requirementSpecificationDtoPerson.WorkAmountSpecifications, x =>
            new DbWorkAmountSpecificationRequirementConnection()
            {
                RequirementSpecificationId = r.EntityId,
                WorkAmountSpecificationId = x.EntityId
            });
        r.LocationSpecifications = MappingTools.MapArrayToList(requirementSpecificationDtoPerson.LocationSpecifications, x =>
            new DbLocationSpecificationRequirementConnection()
            {
                RequirementSpecificationId = r.EntityId,
                LocationSpecificationId = x.EntityId
            });
        return r;
    }
    
    [MapperIgnoreTarget(nameof(DbRequirementSpecificationMaterial.MaterialSpecifications))]
    [MapperIgnoreSource(nameof(RequirementSpecificationDtoMaterial.MaterialSpecifications))]
    [MapperIgnoreTarget(nameof(DbRequirementSpecificationMaterial.LocationSpecifications))]
    [MapperIgnoreSource(nameof(RequirementSpecificationDtoMaterial.LocationSpecifications))]
    [MapperIgnoreTarget(nameof(DbRequirementSpecification.TimeSpecifications))]
    [MapperIgnoreSource(nameof(RequirementSpecificationDtoMaterial.TimeSpecifications))]
    [MapperIgnoreTarget(nameof(DbRequirementSpecification.QuantitySpecification))]
    [MapperIgnoreSource(nameof(RequirementSpecificationDtoMaterial.QuantitySpecification))]
    internal static partial DbRequirementSpecificationMaterial ToDbRequirementSpecificationMaterialInner(this RequirementSpecificationDtoMaterial requirementSpecificationDtoMaterial);
    
    [UserMapping(Default = true)]
    public static DbRequirementSpecificationMaterial ToDbRequirementSpecificationMaterial(
        this RequirementSpecificationDtoMaterial requirementSpecificationDtoMaterial)
    {
        var r = requirementSpecificationDtoMaterial.ToDbRequirementSpecificationMaterialInner();
        SetTimeAndQuantitySpecification(r, requirementSpecificationDtoMaterial);
        r.MaterialSpecifications = MappingTools.MapArrayToList(requirementSpecificationDtoMaterial.MaterialSpecifications, x =>
            new DbMaterialSpecificationRequirementConnection()
            {
                RequirementSpecificationId = r.EntityId,
                MaterialSpecificationId = x.EntityId
            });
        r.LocationSpecifications = MappingTools.MapArrayToList(requirementSpecificationDtoMaterial.LocationSpecifications, x =>
            new DbLocationSpecificationRequirementConnection()
            {
                RequirementSpecificationId = r.EntityId,
                LocationSpecificationId = x.EntityId
            });
        return r;
    }
    
    [MapperIgnoreTarget(nameof(DbRequirementSpecificationMoney.MaterialSpecifications))]
    [MapperIgnoreSource(nameof(RequirementSpecificationDtoMoney.MaterialSpecifications))]
    [MapperIgnoreTarget(nameof(DbRequirementSpecification.TimeSpecifications))]
    [MapperIgnoreSource(nameof(RequirementSpecificationDtoMoney.TimeSpecifications))]
    [MapperIgnoreTarget(nameof(DbRequirementSpecification.QuantitySpecification))]
    [MapperIgnoreSource(nameof(RequirementSpecificationDtoMoney.QuantitySpecification))]
    internal static partial DbRequirementSpecificationMoney ToDbRequirementSpecificationMoneyInner(this RequirementSpecificationDtoMoney requirementSpecificationDtoMoney);
    
    [UserMapping(Default = true)]
    public static DbRequirementSpecificationMoney ToDbRequirementSpecificationMoney(
        this RequirementSpecificationDtoMoney requirementSpecificationDtoMoney)
    {
        var r = requirementSpecificationDtoMoney.ToDbRequirementSpecificationMoneyInner();
        SetTimeAndQuantitySpecification(r, requirementSpecificationDtoMoney);
        r.MaterialSpecifications = MappingTools.MapArrayToList(requirementSpecificationDtoMoney.MaterialSpecifications, x =>
            new DbMaterialSpecificationRequirementConnection()
            {
                RequirementSpecificationId = r.EntityId,
                MaterialSpecificationId = x.EntityId
            });
        return r;
    }
   
    
}