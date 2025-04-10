using Application.Common;
using Application.Filter;
using Application.Selectors;

namespace Application.GetUsersProjects.GetUsersProjects;

public class GetUsersProjectsRequest : BaseRequest<GetUsersProjectsResponse>
{
    public ProjectFilter? Filter { get; init; }
    public ProjectSelector? Selector { get; init; }
}

