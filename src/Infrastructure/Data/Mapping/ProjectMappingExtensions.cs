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
        r.LocationSpecifications = MappingTools.MapArray(project.LocationSpecifications, x => new DbLocationSpecificationProjectConnection()
        {
            // Project = r,
            ProjectId = r.EntityId,
            // LocationSpecification = x.ToDbLocationSpecification(),
            LocationSpecificationId = x.EntityId
        });
        r.TimeSpecifications = MappingTools.MapArray(project.TimeSpecifications, x => new DbTimeSpecificationProjectConnection()
        {
            // Project = r,
            ProjectId = r.EntityId,
            // TimeSpecification = x.ToDbTimeSpecification(),
            TimeSpecificationId = x.EntityId
        });
        r.RequirementSpecifications = MappingTools.MapArray(project.RequirementSpecifications, x => new DbRequirementSpecificationProjectConnection()
        {
            // Project = r,
            ProjectId = r.EntityId,
            // RequirementSpecification = x.ToDbRequirementSpecification(),
            RequirementSpecificationId = x.EntityId
        });
        r.ContactSpecifications = MappingTools.MapArray(project.ContactSpecifications, x => new DbContactSpecificationProjectConnection()
        {
            // Project = r,
            ProjectId = r.EntityId,
            // ContactSpecification = x.ToDbContactSpecification(),
            ContactSpecificationId = x.EntityId
        });
        r.ProjectTags = MappingTools.MapArray(project.ProjectTags, x => new DbProjectTagConnection()
        {
            // Project = r,
            ProjectId = r.EntityId,
            // ProjectTag = x.ToDbProjectTag(),
            ProjectTagId = x.EntityId
        });
        r.DescriptionSpecifications = MappingTools.MapArray(project.DescriptionSpecifications, x => new DbDescriptionSpecificationProjectConnection()
        {
            // Project = r,
            ProjectId = r.EntityId,
            // DescriptionSpecification = x.ToDbDescriptionSpecification(),
            DescriptionSpecificationId = x.EntityId
        });
        r.GraphicsSpecifications = MappingTools.MapArray(project.GraphicsSpecifications, x => new DbGraphicsSpecificationProjectConnection()
        {
            // Project = r,
            ProjectId = r.EntityId,
            // GraphicsSpecification = x.ToDbGraphicsSpecification(),
            GraphicsSpecificationId = x.EntityId
        });
        r.Owner = new DbPersonProjectOwnerConnection()
        {
            // Person = project.Owner.ToDbPerson(),
            // Project = r,
            PersonId = project.Owner.EntityId,
            ProjectId = r.EntityId
        };
        r.Contributors = MappingTools.MapArray(project.Contributors, x => new DbPersonProjectContributorConnection()
        {
            // Project = r,
            ProjectId = r.EntityId,
            // Person = x.ToDbPerson(),
            PersonId = x.EntityId
        });
        r.RelatedProjects = MappingTools.MapArray(project.RelatedProjects, x => new DbProjectConnection()
        {
            // Project = r,
            ProjectId = r.EntityId,
            RelatedProject = x.Project.ToDbProject(),
            RelatedProjectId = x.EntityId,
            Type = x.Type,
        });
        r.ConnectedOrganizations = MappingTools.MapArray(project.ConnectedOrganizations, x => new DbOrganizationProjectConnection()
        {
            OrganizationId = x.EntityId,
            ProjectId = r.EntityId
        });
        return r;
    }
    
    internal static partial Project ToProjectInner(this DbProject dbProject);
}