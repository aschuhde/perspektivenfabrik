using Application.Common;
using Application.Filter;
using Application.Selectors;

namespace Application.GetProjects.GetProjects;

public class GetProjectsRequest : BaseRequest<GetProjectsResponse>
{
    public ProjectFilter? Filter { get; init; }
    public ProjectSelector? Selector { get; init; }
}

