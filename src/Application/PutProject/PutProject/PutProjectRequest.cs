using Application.Common;
using Application.Models.ApiModels;

namespace Application.PutProject.PutProject;

public sealed class PutProjectRequest : BaseRequest<PutProjectResponse>
{
    public Guid EntityId { get; init; } = Guid.Empty;
    
    public required ApiProjectBody Project { get; init; }
}

