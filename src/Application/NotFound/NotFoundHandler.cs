using Application.Common;

namespace Application.NotFound;

public class NotFoundHandler(IServiceProvider serviceProvider) : BaseHandler<NotFoundRequest, NotFoundResponse>(serviceProvider)
{
    public override Task<NotFoundResponse> ExecuteAsync(NotFoundRequest command, CancellationToken ct)
    {
        return Task.FromResult(new NotFoundResponse());
    }
}
