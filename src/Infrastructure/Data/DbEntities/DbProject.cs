using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;
using Infrastructure.Data.DbDataTypes;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.DbEntities;

[Table("Projects")]
public sealed class DbProject : DbEntity
{
    public required ProjectPhase Phase { get; init; }
    public required ProjectType Type { get; init; }
    public required ProjectVisibility Visibility  { get; init; }
    
    public DbLocationSpecificationProjectConnection[] LocationSpecifications { get; set; } =
        Array.Empty<DbLocationSpecificationProjectConnection>();
    public DbTimeSpecificationProjectConnection[] TimeSpecifications { get; set; } =
        Array.Empty<DbTimeSpecificationProjectConnection>();
    public DbRequirementSpecificationProjectConnection[] RequirementSpecifications { get; set; } =
        Array.Empty<DbRequirementSpecificationProjectConnection>();
    public DbContactSpecificationProjectConnection[] ContactSpecifications { get; set; } =
        Array.Empty<DbContactSpecificationProjectConnection>();
    [MaxLength(Constants.StringLengths.Medium)]
    public required string ProjectName { get; init; }
    public DbProjectTagConnection[] ProjectTags { get; set; } =
        Array.Empty<DbProjectTagConnection>();
    public required DbFormattedTitle ProjectTitle { get; init; }
    public DbDescriptionSpecificationProjectConnection[] DescriptionSpecifications { get; set; } =
        Array.Empty<DbDescriptionSpecificationProjectConnection>();
    public DbGraphicsSpecificationProjectConnection[] GraphicsSpecifications { get; set; } =
        Array.Empty<DbGraphicsSpecificationProjectConnection>();
    public required bool ConnectedOrganizationsSameAsOwner { get; init; }
    public DbOrganizationProjectConnection[] ConnectedOrganizations { get; set; } =
        Array.Empty<DbOrganizationProjectConnection>();
    public DbPersonProjectOwnerConnection? Owner { get; set; }
    public DbPersonProjectContributorConnection[] Contributors { get; set; } =
        Array.Empty<DbPersonProjectContributorConnection>();
    [InverseProperty(nameof(DbProjectConnection.Project))]
    public DbProjectConnection[] RelatedProjects { get; set; } =
        Array.Empty<DbProjectConnection>();
}