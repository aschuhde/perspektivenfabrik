using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;
using Infrastructure.Data.DbDataTypes;
using Microsoft.EntityFrameworkCore;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.DbEntities;

[Table("Projects")]
public sealed class DbProject : DbEntity
{
    public required ProjectPhase Phase { get; set; }
    public required ProjectType Type { get; set; }
    public required ProjectVisibility Visibility  { get; set; }
    public required ApprovalStatus ApprovalStatus  { get; set; }
    public required string? ApprovalStatusLastChangedByName  { get; set; }
    public required string? ApprovalStatusLastChangeReason  { get; set; }
    
    [MapperIgnore]
    public bool IsSoftDeleted { get; set; } = false;
    
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public List<DbLocationSpecificationProjectConnection>? LocationSpecifications { get; set; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public List<DbTimeSpecificationProjectConnection>? TimeSpecifications { get; set; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public List<DbRequirementSpecificationProjectConnection>? RequirementSpecifications { get; set; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public List<DbContactSpecificationProjectConnection>? ContactSpecifications { get; set; }
    [MaxLength(Constants.StringLengths.Medium)]
    public required string ProjectName { get; set; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public List<DbProjectTagConnection>? ProjectTags { get; set; }
    public required DbFormattedTitle ProjectTitle { get; init; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public List<DbDescriptionSpecificationProjectConnection>? DescriptionSpecifications { get; set; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public List<DbGraphicsSpecificationProjectConnection>? GraphicsSpecifications { get; set; }
    public required bool ConnectedOrganizationsSameAsOwner { get; set; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public List<DbOrganizationProjectConnection>? ConnectedOrganizations { get; set; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public DbPersonProjectOwnerConnection? Owner { get; set; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public List<DbPersonProjectContributorConnection>? Contributors { get; set; }
    [InverseProperty(nameof(DbProjectConnection.Project))]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public List<DbProjectConnection>? RelatedProjects { get; set; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    [MapperIgnore]
    public List<DbProjectImage>? ProjectImages { get; set; }
    
    [MapperIgnore]
    [NotMapped]
    public List<DbFieldTranslation> FieldTranslations { get; set; } = [];

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
      if (this.ApprovalStatus != project.ApprovalStatus)
      {
        this.ApprovalStatus = project.ApprovalStatus;
      }
      if (this.ApprovalStatusLastChangedByName != project.ApprovalStatusLastChangedByName)
      {
        this.ApprovalStatusLastChangedByName = project.ApprovalStatusLastChangedByName;
      }
      if (this.ApprovalStatusLastChangeReason != project.ApprovalStatusLastChangeReason)
      {
        this.ApprovalStatusLastChangeReason = project.ApprovalStatusLastChangeReason;
      }
      if (this.ConnectedOrganizationsSameAsOwner != project.ConnectedOrganizationsSameAsOwner)
      {
        this.ConnectedOrganizationsSameAsOwner = project.ConnectedOrganizationsSameAsOwner;
      }
      this.ProjectTitle.Update(project.ProjectTitle);
      this.Contributors = this.Contributors?.GetUpdateConnections(project.Contributors, x => x.ProjectId, x => x.PersonId) ?? project.Contributors;
      this.ContactSpecifications = this.ContactSpecifications?.GetUpdateConnections(project.ContactSpecifications, x => x.ProjectId, x => x.ContactSpecificationId) ?? project.ContactSpecifications;
      this.LocationSpecifications = this.LocationSpecifications?.GetUpdateConnections(project.LocationSpecifications, x => x.ProjectId, x => x.LocationSpecificationId) ?? project.LocationSpecifications;
      this.TimeSpecifications = this.TimeSpecifications?.GetUpdateConnections(project.TimeSpecifications, x => x.ProjectId, x => x.TimeSpecificationId) ?? project.TimeSpecifications;
      this.RequirementSpecifications = this.RequirementSpecifications?.GetUpdateConnections(project.RequirementSpecifications, x => x.ProjectId, x => x.RequirementSpecificationId) ?? project.RequirementSpecifications;
      this.ProjectTags = this.ProjectTags?.GetUpdateConnections(project.ProjectTags, x => x.ProjectId, x => x.ProjectTagId) ?? project.ProjectTags;
      this.DescriptionSpecifications = this.DescriptionSpecifications?.GetUpdateConnections(project.DescriptionSpecifications, x => x.ProjectId, x => x.DescriptionSpecificationId) ?? project.DescriptionSpecifications;
      this.GraphicsSpecifications = this.GraphicsSpecifications?.GetUpdateConnections(project.GraphicsSpecifications, x => x.ProjectId, x => x.GraphicsSpecificationId) ?? project.GraphicsSpecifications;
      this.ConnectedOrganizations = this.ConnectedOrganizations?.GetUpdateConnections(project.ConnectedOrganizations, x => x.ProjectId, x => x.OrganizationId) ?? project.ConnectedOrganizations;
      this.RelatedProjects = this.RelatedProjects?.GetUpdateConnections(project.RelatedProjects, x => x.ProjectId, x => x.RelatedProjectId) ?? project.RelatedProjects;

      if ( this.Owner?.PersonId != project.Owner?.PersonId)
      {
        this.Owner = project.Owner == null ? null : new DbPersonProjectOwnerConnection()
        {
          PersonId = project.Owner.PersonId, ProjectId = this.EntityId
        };
      }
      base.UpdateToTarget(target);
    }
}
