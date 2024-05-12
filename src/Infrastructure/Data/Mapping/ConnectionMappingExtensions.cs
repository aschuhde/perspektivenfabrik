using Domain.Entities;
using Infrastructure.Data.DbEntities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;

[Mapper]
public static partial class ConnectionMappingExtensions
{
    public static TimeSpecification DbTimeSpecificationProjectConnectionToTimeSpecification(
        this DbTimeSpecificationProjectConnection dbTimeSpecificationProjectConnection) =>
        dbTimeSpecificationProjectConnection.TimeSpecification!.ToTimeSpecification();
    
    public static TimeSpecificationMoment DbTimeSpecificationMomentPeriodConnectionToTimeSpecificationMoment(
        this DbTimeSpecificationMomentPeriodConnection dbTimeSpecificationMomentPeriodConnection) =>
        dbTimeSpecificationMomentPeriodConnection.TimeSpecificationMoment!.ToTimeSpecificationMoment();
    
    public static TimeSpecification DbTimeSpecificationRequirementConnectionToTimeSpecification(
        this DbTimeSpecificationRequirementConnection dbTimeSpecificationRequirementConnection) =>
        dbTimeSpecificationRequirementConnection.TimeSpecification!.ToTimeSpecification();
    
    public static LocationSpecification DbLocationSpecificationProjectConnectionToLocationSpecification(
    this DbLocationSpecificationProjectConnection dbLocationSpecificationProjectConnection) =>
    dbLocationSpecificationProjectConnection.LocationSpecification!.ToLocationSpecification();
    
    public static RequirementSpecification DbRequirementSpecificationProjectConnectionToRequirementSpecification(
        this DbRequirementSpecificationProjectConnection dbRequirementSpecificationProjectConnection) =>
        dbRequirementSpecificationProjectConnection.RequirementSpecification!.ToRequirementSpecification();
    
    public static MaterialSpecification DbMaterialSpecificationRequirementConnectionToMaterialSpecification(
        this DbMaterialSpecificationRequirementConnection dbMaterialSpecificationRequirementConnection) =>
        dbMaterialSpecificationRequirementConnection.MaterialSpecification!.ToMaterialSpecification();
    
    public static WorkAmountSpecification DbWorkAmountSpecificationRequirementConnectionToWorkAmountSpecification(
        this DbWorkAmountSpecificationRequirementConnection dbWorkAmountSpecificationRequirementConnection) =>
        dbWorkAmountSpecificationRequirementConnection.WorkAmountSpecification!.ToWorkAmountSpecification();
    
    public static SkillSpecification DbSkillSpecificationRequirementConnectionToSkillSpecification(
        this DbSkillSpecificationRequirementConnection dbSkillSpecificationRequirementConnection) =>
        dbSkillSpecificationRequirementConnection.SkillSpecification!.ToSkillSpecification();
    
    public static QuantitySpecification DbQuantitySpecificationRequirementConnectionToQuantitySpecification(
        this DbQuantitySpecificationRequirementConnection dbQuantitySpecificationRequirementConnection) =>
        dbQuantitySpecificationRequirementConnection.QuantitySpecification!.ToQuantitySpecification();
    
    public static ContactSpecification DbContactSpecificationProjectConnectionToContactSpecification(
        this DbContactSpecificationProjectConnection dbContactSpecificationProjectConnection) =>
        dbContactSpecificationProjectConnection.ContactSpecification!.ToContactSpecification();
    
    public static ProjectTag DbProjectTagConnectionToContactSpecification(
        this DbProjectTagConnection dbProjectTagConnection) =>
        dbProjectTagConnection.ProjectTag!.ToProjectTag();
    
    public static DescriptionSpecification DbDescriptionSpecificationProjectConnectionToDescriptionSpecification(
        this DbDescriptionSpecificationProjectConnection dbDescriptionSpecificationProjectConnection) =>
        dbDescriptionSpecificationProjectConnection.DescriptionSpecification!.ToDescriptionSpecification();
    
    public static GraphicsSpecification DbGraphicsSpecificationProjectConnectionToGraphicsSpecification(
        this DbGraphicsSpecificationProjectConnection dbGraphicsSpecificationProjectConnection) =>
        dbGraphicsSpecificationProjectConnection.GraphicsSpecification!.ToGraphicsSpecification();
    
    public static Organization DbOrganizationConnectionToOrganization(
        this DbOrganizationConnection dbOrganizationConnection) =>
        dbOrganizationConnection.Organization!.ToOrganization();
    
    public static Person DbPersonProjectOwnerConnectionToOrganization(
        this DbPersonProjectOwnerConnection dbPersonProjectOwnerConnection) =>
        dbPersonProjectOwnerConnection.Person!.ToPerson();
    
    public static Person DbPersonProjectContributorConnectionToOrganization(
        this DbPersonProjectContributorConnection dbPersonProjectContributorConnection) =>
        dbPersonProjectContributorConnection.Person!.ToPerson();
}