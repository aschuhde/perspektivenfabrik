namespace Domain.Entities;

public sealed class ProjectTagDto : BaseEntityWithIdDto
{
    public required string TagName { get; init; }    
}