using Domain.Enums;

namespace Domain.Entities;

public sealed class ProjectConnectionDto : BaseEntityWithIdDto
{
    public required ProjectDto Project { get; init; }
    public required ProjectConnectionType Type { get; init; }
}