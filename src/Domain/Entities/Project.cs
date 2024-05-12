using Domain.DataTypes;
using Domain.Enums;

namespace Domain.Entities;

public sealed class Project : BaseEntity
{
    public required ProjectPhase Phase { get; init; }
    public required ProjectType Type { get; init; }
    public required ProjectVisibility Visibility  { get; init; }
    public required LocationSpecification[] LocationSpecifications { get; init; }
    public required TimeSpecification[] TimeSpecifications { get; init; }
    public required RequirementSpecification[] RequirementSpecifications { get; init; }
    public required ContactSpecification[] ContactSpecifications { get; init; }
    public required string ProjectName { get; init; }
    public required ProjectTag[] ProjectTags { get; init; }
    public required FormattedTitle ProjectTitle { get; init; }
    public required DescriptionSpecification[] DescriptionSpecifications { get; init; }
    public required GraphicsSpecification[] GraphicsSpecifications { get; init; }
    public required bool ConnectedOrganizationsSameAsOwner { get; init; }
    public required Organization[] ConnectedOrganizations { get; init; }
    public required Person Owner { get; init; }
    public required Person[] Contributors { get; init; }
    public required ProjectConnection[] RelatedProjects { get; init; }
}