using Domain.Enums;

namespace Domain.Entities;

public sealed class ModificationHistoryItemDto : BaseEntityWithIdDto
{
    public DateTimeOffset Timestamp { get; init; } = DateTimeOffset.UtcNow;
    public string? Message { get; init; }
    public HistoryEntryType HistoryEntryType { get; set; } = HistoryEntryType.Unknown;
}