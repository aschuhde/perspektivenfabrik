using Application.Common;
using Application.Services;

namespace Application.PutCleanupDatabase.PutCleanupDatabase;

public sealed class PutCleanupDatabaseHandler(IServiceProvider serviceProvider, ICommonDataService commonDataService) : BaseHandler<PutCleanupDatabaseRequest, PutCleanupDatabaseResponse>(serviceProvider)
{
    public override async Task<PutCleanupDatabaseResponse> ExecuteAsync(PutCleanupDatabaseRequest command, CancellationToken ct)
    {
        return new PutCleanupDatabaseResponse()
        {
            Messages = await commonDataService.CleanupDatabase(ct)
        };
    }
}
