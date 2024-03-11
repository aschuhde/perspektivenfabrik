using Application.Common;

namespace Application.Example.GetExample;

public class GetExampleHandler(IServiceProvider serviceProvider) : BaseHandler<GetExampleRequest, GetExampleResponse>(serviceProvider)
{
    public override Task<GetExampleResponse> ExecuteAsync(GetExampleRequest command, CancellationToken ct)
    {
        return Task.FromResult(new GetExampleResponse() { });
    }
}
