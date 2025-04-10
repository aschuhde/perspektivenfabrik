using Application.Common;

namespace Application.GetProject.GetProject;

public class GetProjectRequest : BaseRequest<GetProjectResponse>
{
    public required string ProjectIdentifier { get; init; }
}

