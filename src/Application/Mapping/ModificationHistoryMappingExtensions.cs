using Application.Models.ApiModels;
using Common;
using Domain.Entities;

namespace Application.Mapping;


public static partial class ApiMappingExtensions
{
    public static partial ModificationHistoryDto ToHistory(this ApiModificationHistory apiHistory);
    
    public static partial ApiModificationHistory ToApiHistory(this ModificationHistoryDto historyDto);


    public static ModificationHistoryItemDto ToHistoryItem(this ApiModificationHistoryItem apiHistoryItem)
    {
        return new ModificationHistoryItemDto()
        {
            HistoryEntryType = apiHistoryItem.HistoryEntryType,
            Message = apiHistoryItem.Message?.ToString(),
            Timestamp = apiHistoryItem.Timestamp
        };
    }
    public static ApiModificationHistoryItem ToApiHistoryItem(this ModificationHistoryItemDto historyItemDto)
    {
        return new ApiModificationHistoryItem()
        {
            HistoryEntryType = historyItemDto.HistoryEntryType,
            Message = historyItemDto.Message != null ? new Message(historyItemDto.Message) : null,
            Timestamp = historyItemDto.Timestamp
        };
    }
}