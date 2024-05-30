using Application.Common.Response;
using Application.Models.ApiModels;

namespace Application.Models.ProjectService;

public sealed class CreateProjectResult : BaseServiceResult
{
    public ApiProject? Project { get; init; }

    public override ErrorResponseData ToErrorResponseData()
    {
        throw new NotImplementedException();
    }
}