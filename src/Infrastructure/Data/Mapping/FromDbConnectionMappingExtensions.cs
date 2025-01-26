using Domain.Entities;
using Infrastructure.Data.DbEntities;

namespace Infrastructure.Data.Mapping;


public static partial class MappingExtensions
{
    public static OrganizationDto DbOrganizationProjectConnectionToOrganization(
        this DbOrganizationProjectConnection dbOrganizationProjectConnection) =>
        dbOrganizationProjectConnection.Organization!.ToOrganization();
    public static TimeSpecificationDto DbTimeSpecificationProjectConnectionToTimeSpecification(
        this DbTimeSpecificationProjectConnection dbTimeSpecificationProjectConnection) =>
        dbTimeSpecificationProjectConnection.TimeSpecification!.ToTimeSpecification();
    
    public static TimeSpecificationDto DbTimeSpecificationRequirementConnectionToTimeSpecification(
        this DbTimeSpecificationRequirementConnection dbTimeSpecificationRequirementConnection) =>
        dbTimeSpecificationRequirementConnection.TimeSpecification!.ToTimeSpecification();
    
    public static LocationSpecificationDto DbLocationSpecificationProjectConnectionToLocationSpecification(
    this DbLocationSpecificationProjectConnection dbLocationSpecificationProjectConnection) =>
    dbLocationSpecificationProjectConnection.LocationSpecification!.ToLocationSpecification();
    
    public static RequirementSpecificationDto DbRequirementSpecificationProjectConnectionToRequirementSpecification(
        this DbRequirementSpecificationProjectConnection dbRequirementSpecificationProjectConnection) =>
        dbRequirementSpecificationProjectConnection.RequirementSpecification!.ToRequirementSpecification();
    
    public static MaterialSpecificationDto DbMaterialSpecificationRequirementConnectionToMaterialSpecification(
        this DbMaterialSpecificationRequirementConnection dbMaterialSpecificationRequirementConnection) =>
        dbMaterialSpecificationRequirementConnection.MaterialSpecification!.ToMaterialSpecification();
    
    public static WorkAmountSpecificationDto DbWorkAmountSpecificationRequirementConnectionToWorkAmountSpecification(
        this DbWorkAmountSpecificationRequirementConnection dbWorkAmountSpecificationRequirementConnection) =>
        dbWorkAmountSpecificationRequirementConnection.WorkAmountSpecification!.ToWorkAmountSpecification();
    
    public static LocationSpecificationDto DbLocationSpecificationRequirementConnectionToLocationSpecification(
        this DbLocationSpecificationRequirementConnection dbLocationSpecificationRequirementConnection) =>
        dbLocationSpecificationRequirementConnection.LocationSpecification!.ToLocationSpecification();
    
    public static SkillSpecificationDto DbSkillSpecificationRequirementConnectionToSkillSpecification(
        this DbSkillSpecificationRequirementConnection dbSkillSpecificationRequirementConnection) =>
        dbSkillSpecificationRequirementConnection.SkillSpecification!.ToSkillSpecification();
    
    public static QuantitySpecificationDto DbQuantitySpecificationRequirementConnectionToQuantitySpecification(
        this DbQuantitySpecificationRequirementConnection dbQuantitySpecificationRequirementConnection) =>
        dbQuantitySpecificationRequirementConnection.QuantitySpecification!.ToQuantitySpecification();
    
    public static ContactSpecificationDto DbContactSpecificationProjectConnectionToContactSpecification(
        this DbContactSpecificationProjectConnection dbContactSpecificationProjectConnection) =>
        dbContactSpecificationProjectConnection.ContactSpecification!.ToContactSpecification();
    
    public static ProjectTagDto DbProjectTagConnectionToProjectTag(
        this DbProjectTagConnection dbProjectTagConnection) =>
        dbProjectTagConnection.ProjectTag!.ToProjectTag();
    
    public static ProjectConnectionDto DbProjectConnectionToProjectConnection(
        this DbProjectConnection dbProjectConnection) =>
        new()
        {
            Project = dbProjectConnection.RelatedProject!.ToProject(),
            Type = dbProjectConnection.Type,
            EntityId = dbProjectConnection.EntityId
        };
    
    public static DescriptionSpecificationDto DbDescriptionSpecificationProjectConnectionToDescriptionSpecification(
        this DbDescriptionSpecificationProjectConnection dbDescriptionSpecificationProjectConnection) =>
        dbDescriptionSpecificationProjectConnection.DescriptionSpecification!.ToDescriptionSpecification();
    
    public static GraphicsSpecificationDto DbGraphicsSpecificationProjectConnectionToGraphicsSpecification(
        this DbGraphicsSpecificationProjectConnection dbGraphicsSpecificationProjectConnection) =>
        dbGraphicsSpecificationProjectConnection.GraphicsSpecification!.ToGraphicsSpecification();
    
    public static OrganizationDto DbOrganizationConnectionToOrganization(
        this DbOrganizationConnection dbOrganizationConnection) =>
        dbOrganizationConnection.Organization!.ToOrganization();
    
    public static PersonDto DbPersonProjectOwnerConnectionToOrganization(
        this DbPersonProjectOwnerConnection dbPersonProjectOwnerConnection) =>
        dbPersonProjectOwnerConnection.Person!.ToPerson();
    
    public static PersonDto DbPersonProjectContributorConnectionToOrganization(
        this DbPersonProjectContributorConnection dbPersonProjectContributorConnection) =>
        dbPersonProjectContributorConnection.Person!.ToPerson();
}