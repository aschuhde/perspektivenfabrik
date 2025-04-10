using Application.Common;

namespace Application.GetUsersProject.GetUsersProject;

public class GetUsersProjectRequest : BaseRequest<GetUsersProjectResponse>
{
    public required string ProjectIdentifier { get; init; }
}

