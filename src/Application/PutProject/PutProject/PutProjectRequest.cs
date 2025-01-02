using Application.Common;
using Application.Models.ApiModels;

namespace Application.PutProject.PutProject;

public sealed class PutProjectRequest : BaseRequest<PutProjectResponse>
{
    public required ApiProject Project { get; init; }
}

