using Application.Models;
using Application.Models.ApiModels;
using FluentValidation;
using FluentValidation.Validators;

namespace Application.Validators;

public class ProjectValidator : AbstractValidator<ApiProject>
{
    public ProjectValidator()
    {
        RuleFor(model => model.Phase).NotEmpty();
        RuleFor(model => model.Type).NotEmpty();
        RuleFor(model => model.Visibility).NotEmpty();
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
        RuleForEach(model => model.ConnectedOrganizations).SetValidator(new OrganizationValidator());
        RuleFor(model => model.Owner).NotNull().SetValidator(new PersonValidator());
        RuleFor(model => model.Contributors).NotNull();
        RuleForEach(model => model.Contributors).SetValidator(new PersonValidator());
        RuleFor(model => model.RelatedProjects).NotNull();
        RuleForEach(model => model.RelatedProjects).SetValidator(new ProjectConnectionValidator());
    }
}