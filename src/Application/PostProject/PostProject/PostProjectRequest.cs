using Application.Common;
using Application.Models;
using Application.Models.ApiModels;

namespace Application.PostProject.PostProject;

public class PostProjectRequest : BaseRequest<PostProjectResponse>
{
    public required ApiProject Project { get; init; }
}

