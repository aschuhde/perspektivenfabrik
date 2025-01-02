using Application.Common;
using Application.Models.ApiModels;

namespace Application.PutProject.PutProject;

public sealed class PutProjectRequest : BaseRequest<PutProjectResponse>
{
    public required Guid EntityId { get; init; }
    
    public required ApiProjectBody Project { get; init; }
}

