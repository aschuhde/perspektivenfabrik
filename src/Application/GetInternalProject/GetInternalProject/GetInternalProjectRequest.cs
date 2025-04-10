using Application.Common;

namespace Application.GetInternalProject.GetInternalProject;

public class GetInternalProjectRequest : BaseRequest<GetInternalProjectResponse>
{
    public required string ProjectIdentifier { get; init; }
}

