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
    public static partial DbProject ToDbProjectInner(this ProjectDto projectDto);
    
    [UserMapping(Default = true)]
    public static DbProject ToDbProject(this ProjectDto projectDto)
    {
        var r = projectDto.ToDbProjectInner();
        r.LocationSpecifications = MappingTools.MapArrayToList(projectDto.LocationSpecifications, x => new DbLocationSpecificationProjectConnection()
        {
            ProjectId = r.EntityId,
            LocationSpecificationId = x.EntityId
        });
        r.TimeSpecifications = MappingTools.MapArrayToList(projectDto.TimeSpecifications, x => new DbTimeSpecificationProjectConnection()
        {
            ProjectId = r.EntityId,
            TimeSpecificationId = x.EntityId
        });
        r.RequirementSpecifications = MappingTools.MapArrayToList(projectDto.RequirementSpecifications, x => new DbRequirementSpecificationProjectConnection()
        {
            ProjectId = r.EntityId,
            RequirementSpecificationId = x.EntityId
        });
        r.ContactSpecifications = MappingTools.MapArrayToList(projectDto.ContactSpecifications, x => new DbContactSpecificationProjectConnection()
        {
            ProjectId = r.EntityId,
            ContactSpecificationId = x.EntityId
        });
        r.ProjectTags = MappingTools.MapArrayToList(projectDto.ProjectTags, x => new DbProjectTagConnection()
        {
            ProjectId = r.EntityId,
            ProjectTagId = x.EntityId
        });
        r.DescriptionSpecifications = MappingTools.MapArrayToList(projectDto.DescriptionSpecifications, x => new DbDescriptionSpecificationProjectConnection()
        {
            ProjectId = r.EntityId,
            DescriptionSpecificationId = x.EntityId
        });
        r.GraphicsSpecifications = MappingTools.MapArrayToList(projectDto.GraphicsSpecifications, x => new DbGraphicsSpecificationProjectConnection()
        {
            ProjectId = r.EntityId,
            GraphicsSpecificationId = x.EntityId
        });
        r.Owner = new DbPersonProjectOwnerConnection()
        {
            PersonId = projectDto.Owner.EntityId,
            ProjectId = r.EntityId
        };
        r.Contributors = MappingTools.MapArrayToList(projectDto.Contributors, x => new DbPersonProjectContributorConnection()
        {
            ProjectId = r.EntityId,
            PersonId = x.EntityId
        });
        r.RelatedProjects = MappingTools.MapArrayToList(projectDto.RelatedProjects, x => new DbProjectConnection()
        {
            EntityId = x.EntityId,
            ProjectId = r.EntityId,
            RelatedProjectId = x.Project.EntityId,
            Type = x.Type,
        });
        r.ConnectedOrganizations = MappingTools.MapArrayToList(projectDto.ConnectedOrganizations, x => new DbOrganizationProjectConnection()
        {
            OrganizationId = x.EntityId,
            ProjectId = r.EntityId
        });
        return r;
    }
    
    public static partial ProjectDto ToProject(this DbProject dbProject);
}