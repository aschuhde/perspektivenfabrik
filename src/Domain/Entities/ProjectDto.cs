using Domain.DataTypes;
using Domain.Enums;

namespace Domain.Entities;

public sealed class ProjectDto : BaseEntityDto
{
    public required ProjectPhase Phase { get; init; }
    public required ProjectType Type { get; init; }
    public required ProjectVisibility Visibility  { get; init; }
    public required LocationSpecificationDto[] LocationSpecifications { get; init; }
    public required TimeSpecificationDto[] TimeSpecifications { get; init; }
    public required RequirementSpecificationDto[] RequirementSpecifications { get; init; }
    public required ContactSpecificationDto[] ContactSpecifications { get; init; }
    public required string ProjectName { get; init; }
    public TranslationValue[] ProjectNameTranslations { get; set; } = [];
    public required ProjectTagDto[] ProjectTags { get; init; }
    public required FormattedTitle ProjectTitle { get; init; }
    public required DescriptionSpecificationDto[] DescriptionSpecifications { get; init; }
    public required GraphicsSpecificationDto[] GraphicsSpecifications { get; init; }
    public required bool ConnectedOrganizationsSameAsOwner { get; init; }
    public required OrganizationDto[] ConnectedOrganizations { get; init; }
    public required PersonDto Owner { get; init; }
    public required PersonDto[] Contributors { get; init; }
    public required ProjectConnectionDto[] RelatedProjects { get; init; }
    
    public void ApplyTranslations(FieldTranslationDto[] fieldTranslations)
    {
        var projectTranslations = fieldTranslations.Where(x => x.CorrelatedEntityId == EntityId).ToArray();
        ProjectNameTranslations = projectTranslations.Where(x => x.PropertyPath == nameof(ProjectName)).Select(x => x.ToTranslationValue()).ToArray();
        ProjectTitle.ContentTranslations = projectTranslations.Where(x => x.PropertyPath == nameof(ProjectTitle)).Select(x => x.ToTranslationValue()).ToArray();

        foreach (var locationSpecification in LocationSpecifications)
        {
            locationSpecification.ApplyTranslations(fieldTranslations);
        }
        
        foreach (var requirementSpecification in RequirementSpecifications)
        {
            requirementSpecification.ApplyTranslations(fieldTranslations);
        }
        
        foreach (var contactSpecification in ContactSpecifications)
        {
            contactSpecification.ApplyTranslations(fieldTranslations);
        }
        
        foreach (var projectTag in ProjectTags)
        {
            projectTag.ApplyTranslations(fieldTranslations);
        }
        
        foreach (var descriptionSpecification in DescriptionSpecifications)
        {
            descriptionSpecification.ApplyTranslations(fieldTranslations);
        }
    }
}