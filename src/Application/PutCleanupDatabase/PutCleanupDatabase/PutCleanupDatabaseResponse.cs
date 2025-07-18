using Application.Common.Response;

namespace Application.PutCleanupDatabase.PutCleanupDatabase;

public sealed class PutCleanupDatabaseResponse : JsonResponse
{
    public required string[] Messages { get; set; }
}

