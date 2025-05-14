using Application.Models.ApiModels;
using Domain.DataTypes;
using Domain.Entities;
using Domain.Enums;

namespace Application.Mapping;


public static partial class ApiMappingExtensions
{
    public static partial ApiProject ToApiProject(this ProjectDto projectDto);
    
    public static partial ProjectDto ToProject(this ApiProject apiProject);
    public static partial ProjectDto ToProject(this ApiProjectBody apiProjectBody);

    public static ProjectConnectionDto ToProject(this ApiProjectReference apiProjectReference)
    {
        return new ProjectConnectionDto
        {
            Type = apiProjectReference.Type,
            EntityId = Guid.NewGuid(),
            Project = new ProjectDto(){
                EntityId = apiProjectReference.ProjectId,
                Phase = ProjectPhase.Unkown,
                Type = ProjectType.Unkown,
                Visibility = ProjectVisibility.Unkown,
                LocationSpecifications = [],
                TimeSpecifications = [],
                RequirementSpecifications = [],
                ContactSpecifications = [],
                ProjectName = "",
                ProjectNameTranslations = [],
                ProjectTags = [],
                ProjectTitle = new FormattedTitle()
                {
                    RawContentString = "",
                    ContentTranslations = []
                },
                DescriptionSpecifications = [],
                GraphicsSpecifications = [],
                ConnectedOrganizationsSameAsOwner = false,
                ConnectedOrganizations = [],
                Owner = new PersonDto()
                {
                    Email = "",
                    Firstname = "",
                    Lastname = ""
                },
                Contributors = [],
                RelatedProjects = []
            }
        };
    }
}