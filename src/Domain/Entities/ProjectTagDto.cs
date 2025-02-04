namespace Domain.Entities;

public sealed class ProjectTagDto : BaseEntityDto
{
    public required string TagName { get; init; }    
}