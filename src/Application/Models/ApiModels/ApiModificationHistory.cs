namespace Application.Models.ApiModels;

public sealed class ApiModificationHistory : ApiBaseEntityWithId
{
    public ApiModificationHistoryItem[] HistoryItems { get; init; } = Array.Empty<ApiModificationHistoryItem>();
}
