namespace Domain.Entities;

public sealed class ModificationHistoryDto : BaseEntityWithIdDto
{
    public ModificationHistoryItemDto[] HistoryItems { get; init; } = Array.Empty<ModificationHistoryItemDto>();
}