using Domain.Entities;

namespace Application.Models.ProjectService;

public sealed class CreateorUpdateProjectResult : BaseServiceResult
{
    public ProjectDto? Project { get; init; }
}
