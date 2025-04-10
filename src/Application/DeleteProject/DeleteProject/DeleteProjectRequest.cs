using Application.Common;

namespace Application.DeleteProject.DeleteProject;

public class DeleteProjectRequest : BaseRequest<DeleteProjectResponse>
{
    public string ProjectIdentifier { get; set; } = "";
}

