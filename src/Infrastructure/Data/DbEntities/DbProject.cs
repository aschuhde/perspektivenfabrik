using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;
using Infrastructure.Data.DbDataTypes;

namespace Infrastructure.Data.DbEntities;

[Table("Projects")]
public sealed class DbProject : DbEntity
{
    public required ProjectPhase Phase { get; set; }
    public required ProjectType Type { get; set; }
    public required ProjectVisibility Visibility  { get; set; }
    
    public List<DbLocationSpecificationProjectConnection>? LocationSpecifications { get; set; }
    public List<DbTimeSpecificationProjectConnection>? TimeSpecifications { get; set; }
    public List<DbRequirementSpecificationProjectConnection>? RequirementSpecifications { get; set; }
    public List<DbContactSpecificationProjectConnection>? ContactSpecifications { get; set; }
    [MaxLength(Constants.StringLengths.Medium)]
    public required string ProjectName { get; set; }
    public List<DbProjectTagConnection>? ProjectTags { get; set; }
    public required DbFormattedTitle ProjectTitle { get; init; }
    public List<DbDescriptionSpecificationProjectConnection>? DescriptionSpecifications { get; set; }
    public List<DbGraphicsSpecificationProjectConnection>? GraphicsSpecifications { get; set; }
    public required bool ConnectedOrganizationsSameAsOwner { get; set; }
    public List<DbOrganizationProjectConnection>? ConnectedOrganizations { get; set; }
    public DbPersonProjectOwnerConnection? Owner { get; set; }
    public List<DbPersonProjectContributorConnection>? Contributors { get; set; }
    [InverseProperty(nameof(DbProjectConnection.Project))]
    public List<DbProjectConnection>? RelatedProjects { get; set; }

    public override void UpdateToTarget(DbEntityWithId target)
    {
      if(target is not DbProject project) return;
      if (this.ProjectName != project.ProjectName)
      {
        this.ProjectName = project.ProjectName;
      }
      if (this.Phase != project.Phase)
      {
        this.Phase = project.Phase;
      }
      if (this.Type != project.Type)
      {
        this.Type = project.Type;
      }
      if (this.Visibility != project.Visibility)
      {
        this.Visibility = project.Visibility;
      }
      if (this.ConnectedOrganizationsSameAsOwner != project.ConnectedOrganizationsSameAsOwner)
      {
        this.ConnectedOrganizationsSameAsOwner = project.ConnectedOrganizationsSameAsOwner;
      }
      this.ProjectTitle.Update(project.ProjectTitle);
      base.UpdateToTarget(target);
    }
}
