using Application.Common;
using Application.Models.ApiModels;

namespace Application.PostProject.PostProject;

public class PostProjectRequest : BaseRequest<PostProjectResponse>
{
    public required ApiProjectBody Project { get; init; }
}

