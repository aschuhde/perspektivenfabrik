using Application.Models.ApiModels;
using Domain.Enums;
using FluentValidation;

namespace Application.Validators;

public class ProjectValidator : AbstractValidator<ApiProjectBody>
{
    public ProjectValidator()
    {
        RuleFor(model => model.Phase).NotEqual(ProjectPhase.Unkown);
        RuleFor(model => model.Type).NotEqual(ProjectType.Unkown);
        RuleFor(model => model.Visibility).NotEqual(ProjectVisibility.Unkown);
        RuleFor(model => model.LocationSpecifications).NotNull();
        RuleForEach(model => model.LocationSpecifications).SetValidator(new LocationSpecificationValidator());
        RuleFor(model => model.TimeSpecifications).NotNull();
        RuleForEach(model => model.TimeSpecifications).SetValidator(new TimeSpecificationValidator());
        RuleFor(model => model.RequirementSpecifications).NotNull();
        RuleForEach(model => model.RequirementSpecifications).SetValidator(new RequirementSpecificationValidator());
        RuleFor(model => model.ContactSpecifications).NotNull();
        RuleForEach(model => model.ContactSpecifications).SetValidator(new ContactSpecificationValidator());
        RuleFor(model => model.ProjectName).IsRequiredName();
        RuleFor(model => model.ProjectTags).NotNull();
        RuleFor(model => model.ProjectTitle).NotNull();
        RuleFor(model => model.DescriptionSpecifications).NotNull();
        RuleForEach(model => model.DescriptionSpecifications).SetValidator(new DescriptionSpecificationValidator());
        RuleFor(model => model.GraphicsSpecifications).NotNull();
        RuleForEach(model => model.GraphicsSpecifications).SetValidator(new GraphicsSpecificationValidator());
        RuleFor(model => model.ConnectedOrganizationsSameAsOwner).NotNull();
        RuleFor(model => model.ConnectedOrganizations).NotNull();
        RuleForEach(model => model.ConnectedOrganizations).SetValidator(new OrganizationReferenceValidator());
        RuleFor(model => model.Owner).Null();
        RuleFor(model => model.Contributors).NotNull();
        RuleForEach(model => model.Contributors).SetValidator(new PersonReferenceValidator());
        RuleFor(model => model.RelatedProjects).NotNull();
        RuleForEach(model => model.RelatedProjects).SetValidator(new ProjectReferenceValidator());
    }
}
