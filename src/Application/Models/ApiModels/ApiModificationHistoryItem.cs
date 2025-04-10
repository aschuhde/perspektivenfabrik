using Common;
using Domain.Enums;

namespace Application.Models.ApiModels;

public class ApiModificationHistoryItem : ApiBaseEntityWithId
{
    public DateTimeOffset Timestamp { get; init; } = DateTimeOffset.UtcNow;
    public Message? Message { get; init; }
    public required HistoryEntryType HistoryEntryType { get; init; }
}
