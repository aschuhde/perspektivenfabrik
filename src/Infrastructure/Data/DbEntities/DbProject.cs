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
    
    public List<DbLocationSpecificationProjectConnection>? LocationSpecifications { get; set; }
    public List<DbTimeSpecificationProjectConnection>? TimeSpecifications { get; set; }
    public List<DbRequirementSpecificationProjectConnection>? RequirementSpecifications { get; set; }
    public List<DbContactSpecificationProjectConnection>? ContactSpecifications { get; set; }
    [MaxLength(Constants.StringLengths.Medium)]
    public required string ProjectName { get; init; }
    public List<DbProjectTagConnection>? ProjectTags { get; set; }
    public required DbFormattedTitle ProjectTitle { get; init; }
    public List<DbDescriptionSpecificationProjectConnection>? DescriptionSpecifications { get; set; }
    public List<DbGraphicsSpecificationProjectConnection>? GraphicsSpecifications { get; set; }
    public required bool ConnectedOrganizationsSameAsOwner { get; init; }
    public List<DbOrganizationProjectConnection>? ConnectedOrganizations { get; set; }
    public DbPersonProjectOwnerConnection? Owner { get; set; }
    public List<DbPersonProjectContributorConnection>? Contributors { get; set; }
    [InverseProperty(nameof(DbProjectConnection.Project))]
    public List<DbProjectConnection>? RelatedProjects { get; set; }
}