using Domain.Enums;

namespace Domain.Entities;

public sealed class ProjectConnection : BaseEntityWithId
{
    public required Project Project { get; init; }
    public required ProjectConnectionType Type { get; init; }
}