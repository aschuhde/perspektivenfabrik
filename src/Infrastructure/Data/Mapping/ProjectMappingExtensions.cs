using Domain.Entities;
using Infrastructure.Data.DbEntities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;


public static partial class MappingExtensions
{
    [MapperIgnoreTarget(nameof(DbProject.LocationSpecifications))]
    [MapperIgnoreTarget(nameof(DbProject.TimeSpecifications))]
    [MapperIgnoreTarget(nameof(DbProject.RequirementSpecifications))]
    [MapperIgnoreTarget(nameof(DbProject.ContactSpecifications))]
    [MapperIgnoreTarget(nameof(DbProject.ProjectTags))]
    [MapperIgnoreTarget(nameof(DbProject.DescriptionSpecifications))]
    [MapperIgnoreTarget(nameof(DbProject.GraphicsSpecifications))]
    [MapperIgnoreTarget(nameof(DbProject.Owner))]
    [MapperIgnoreTarget(nameof(DbProject.Contributors))]
    [MapperIgnoreTarget(nameof(DbProject.RelatedProjects))]
    [MapperIgnoreTarget(nameof(DbProject.ConnectedOrganizations))]
    public static partial DbProject ToDbProjectInner(this Project project);
    
    [UserMapping(Default = true)]
    public static DbProject ToDbProject(this Project project)
    {
        var r = project.ToDbProjectInner();
        r.LocationSpecifications = MappingTools.MapArrayToList(project.LocationSpecifications, x => new DbLocationSpecificationProjectConnection()
        {
            ProjectId = r.EntityId,
            LocationSpecificationId = x.EntityId
        });
        r.TimeSpecifications = MappingTools.MapArrayToList(project.TimeSpecifications, x => new DbTimeSpecificationProjectConnection()
        {
            ProjectId = r.EntityId,
            TimeSpecificationId = x.EntityId
        });
        r.RequirementSpecifications = MappingTools.MapArrayToList(project.RequirementSpecifications, x => new DbRequirementSpecificationProjectConnection()
        {
            ProjectId = r.EntityId,
            RequirementSpecificationId = x.EntityId
        });
        r.ContactSpecifications = MappingTools.MapArrayToList(project.ContactSpecifications, x => new DbContactSpecificationProjectConnection()
        {
            ProjectId = r.EntityId,
            ContactSpecificationId = x.EntityId
        });
        r.ProjectTags = MappingTools.MapArrayToList(project.ProjectTags, x => new DbProjectTagConnection()
        {
            ProjectId = r.EntityId,
            ProjectTagId = x.EntityId
        });
        r.DescriptionSpecifications = MappingTools.MapArrayToList(project.DescriptionSpecifications, x => new DbDescriptionSpecificationProjectConnection()
        {
            ProjectId = r.EntityId,
            DescriptionSpecificationId = x.EntityId
        });
        r.GraphicsSpecifications = MappingTools.MapArrayToList(project.GraphicsSpecifications, x => new DbGraphicsSpecificationProjectConnection()
        {
            ProjectId = r.EntityId,
            GraphicsSpecificationId = x.EntityId
        });
        r.Owner = new DbPersonProjectOwnerConnection()
        {
            PersonId = project.Owner.EntityId,
            ProjectId = r.EntityId
        };
        r.Contributors = MappingTools.MapArrayToList(project.Contributors, x => new DbPersonProjectContributorConnection()
        {
            ProjectId = r.EntityId,
            PersonId = x.EntityId
        });
        r.RelatedProjects = MappingTools.MapArrayToList(project.RelatedProjects, x => new DbProjectConnection()
        {
            EntityId = x.EntityId,
            ProjectId = r.EntityId,
            RelatedProjectId = x.Project.EntityId,
            Type = x.Type,
        });
        r.ConnectedOrganizations = MappingTools.MapArrayToList(project.ConnectedOrganizations, x => new DbOrganizationProjectConnection()
        {
            OrganizationId = x.EntityId,
            ProjectId = r.EntityId
        });
        return r;
    }
    
    public static partial Project ToProject(this DbProject dbProject);
}