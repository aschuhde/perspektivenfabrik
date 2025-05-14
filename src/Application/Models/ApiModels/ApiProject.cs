using Domain.DataTypes;
using Domain.Enums;

namespace Application.Models.ApiModels;

public sealed class ApiProject : ApiBaseEntity
{
    public required ProjectPhase Phase { get; init; }
    public required ProjectType Type { get; init; }
    public required ProjectVisibility Visibility  { get; init; }
    public required ApiLocationSpecification[] LocationSpecifications { get; init; }
    public required ApiTimeSpecification[] TimeSpecifications { get; init; }
    public required ApiRequirementSpecification[] RequirementSpecifications { get; init; }
    public required ApiContactSpecification[] ContactSpecifications { get; init; }
    public required string ProjectName { get; init; }
    public TranslationValue[] ProjectNameTranslations { get; set; } = [];
    public required ApiProjectTag[] ProjectTags { get; init; }
    public required FormattedTitle ProjectTitle { get; init; }
    public required ApiDescriptionSpecification[] DescriptionSpecifications { get; init; }
    public required ApiGraphicsSpecification[] GraphicsSpecifications { get; init; }
    public required bool ConnectedOrganizationsSameAsOwner { get; init; }
    public required ApiOrganization[] ConnectedOrganizations { get; init; }
    public ApiPerson? Owner { get; set; }
    public required ApiPerson[] Contributors { get; init; }
    public required ApiProjectConnection[] RelatedProjects { get; init; }
    
}
