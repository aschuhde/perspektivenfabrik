using Domain.Entities;
using Infrastructure.Data.DbEntities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;


// public static partial class MappingExtensions
// {
//     public static DbTimeSpecificationProjectConnection TimeSpecificationToDbTimeSpecificationProjectConnection(this TimeSpecification timeSpecificationProjectConnection) =>
//         dbTimeSpecificationProjectConnection.TimeSpecification!.ToTimeSpecification();
//     
//     public static DbTimeSpecificationMomentPeriodConnection TimeSpecificationMomentToDbTimeSpecificationMomentPeriodConnection(this TimeSpecificationMoment timeSpecificationMomentPeriodConnection) =>
//         dbTimeSpecificationMomentPeriodConnection.TimeSpecificationMoment!.ToTimeSpecificationMoment();
//     
//     public static DbTimeSpecificationRequirementConnection TimeSpecificationToDbTimeSpecificationRequirementConnection(this TimeSpecification timeSpecificationRequirementConnection) =>
//         dbTimeSpecificationRequirementConnection.TimeSpecification!.ToTimeSpecification();
//     
//     public static DbLocationSpecificationProjectConnection LocationSpecificationToDbLocationSpecificationProjectConnection(this LocationSpecification locationSpecificationProjectConnection) =>
//     dbLocationSpecificationProjectConnection.LocationSpecification!.ToLocationSpecification();
//     
//     public static DbRequirementSpecificationProjectConnection RequirementSpecificationToDbRequirementSpecificationProjectConnection(this RequirementSpecification requirementSpecificationProjectConnection) =>
//         dbRequirementSpecificationProjectConnection.RequirementSpecification!.ToRequirementSpecification();
//     
//     public static DbMaterialSpecificationRequirementConnection MaterialSpecificationToDbMaterialSpecificationRequirementConnection(this MaterialSpecification materialSpecificationRequirementConnection) =>
//         dbMaterialSpecificationRequirementConnection.MaterialSpecification!.ToMaterialSpecification();
//     
//     public static DbWorkAmountSpecificationRequirementConnection WorkAmountSpecificationToDbWorkAmountSpecificationRequirementConnection(this WorkAmountSpecification workAmountSpecificationRequirementConnection) =>
//         dbWorkAmountSpecificationRequirementConnection.WorkAmountSpecification!.ToWorkAmountSpecification();
//     
//     public static DbSkillSpecificationRequirementConnection SkillSpecificationToDbSkillSpecificationRequirementConnection(this SkillSpecification skillSpecificationRequirementConnection) =>
//         dbSkillSpecificationRequirementConnection.SkillSpecification!.ToSkillSpecification();
//     
//     public static DbQuantitySpecificationRequirementConnection QuantitySpecificationToDbQuantitySpecificationRequirementConnection(this QuantitySpecification quantitySpecificationRequirementConnection) =>
//         dbQuantitySpecificationRequirementConnection.QuantitySpecification!.ToQuantitySpecification();
//     
//     public static DbContactSpecificationProjectConnection ContactSpecificationToDbContactSpecificationProjectConnection(this ContactSpecification contactSpecificationProjectConnection) =>
//         dbContactSpecificationProjectConnection.ContactSpecification!.ToContactSpecification();
//     
//     public static DbProjectTagConnection ContactSpecificationToDbProjectTagConnection(this ProjectTag projectTagConnection) =>
//         dbProjectTagConnection.ProjectTag!.ToProjectTag();
//     
//     public static DbDescriptionSpecificationProjectConnection DescriptionSpecificationToDbDescriptionSpecificationProjectConnection(this DescriptionSpecification descriptionSpecificationProjectConnection) =>
//         dbDescriptionSpecificationProjectConnection.DescriptionSpecification!.ToDescriptionSpecification();
//     
//     public static DbGraphicsSpecificationProjectConnection GraphicsSpecificationToDbGraphicsSpecificationProjectConnection(this GraphicsSpecification graphicsSpecificationProjectConnection) =>
//         dbGraphicsSpecificationProjectConnection.GraphicsSpecification!.ToGraphicsSpecification();
//     
//     public static DbOrganizationConnection OrganizationToDbOrganizationConnection(this Organization organizationConnection) =>
//         dbOrganizationConnection.Organization!.ToOrganization();
//     
//     public static Person OrganizationToDbPersonProjectOwnerConnection(
//         this wnerConnectionToDbPersonProjec wnerConnectionTodbPersonProjec) =>
//         wnerConnectionTodbPersonProjec.Person!.ToPerson();
//     
//     public static Person OrganizationToDbPersonProjectContributorConnection(
//         this rConnectionToDbPersonProjectContribu rConnectionTodbPersonProjectContribu) =>
//         rConnectionTodbPersonProjectContribu.Person!.ToPerson();
// }