using Domain.Entities;
using Domain.Enums;
using Infrastructure.Data.DbEntities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;


public static partial class MappingExtensions
{
    [MapperIgnoreTarget(nameof(DbModificationHistory.HistoryItems))]
    [MapperIgnoreSource(nameof(ModificationHistoryDto.HistoryItems))]
    internal static partial DbModificationHistory ToDbHistoryInner(this ModificationHistoryDto historyDto);
    
    [UserMapping(Default = true)]
    public static DbModificationHistory ToDbHistory(this ModificationHistoryDto historyDto)
    {
        var h = historyDto.ToDbHistoryInner();
        h.HistoryItems = MappingTools.MapArrayToList(historyDto.HistoryItems, x => x.ToDbHistoryItem(historyDto));
        return h;
    }

    public static partial ModificationHistoryDto ToHistory(this DbModificationHistory dbHistory);

    
    
    internal static DbModificationHistoryConnection ToDbModificationHistoryConnection(this ModificationHistoryDto historyDto)
    {
        return new DbModificationHistoryConnection()
        {
            HistoryId = historyDto.EntityId
        };
    }
    internal static ModificationHistoryDto ToModificationHistory(this DbModificationHistoryConnection history)
    {
        return history.History?.ToHistory() ?? null!;
    }

    [UserMapping(Default = true)]
    public static ModificationHistoryItemDto ToHistoryItem(this DbModificationHistoryItem dbHistoryItem)
    {
        var i = dbHistoryItem.ToHistoryItemInner();
        i.HistoryEntryType = Enum.Parse<HistoryEntryType>(dbHistoryItem.HistoryEntryType);
        return i;
    }
    [MapperIgnoreTarget(nameof(ModificationHistoryItemDto.HistoryEntryType))]
    [MapperIgnoreSource(nameof(DbModificationHistoryItem.HistoryEntryType))]
    [MapperIgnoreSource(nameof(DbModificationHistoryItem.History))]
    [MapperIgnoreSource(nameof(DbModificationHistoryItem.HistoryId))]
    internal static partial ModificationHistoryItemDto ToHistoryItemInner(this DbModificationHistoryItem dbHistoryItem);


    public static DbModificationHistoryItem ToDbHistoryItem(this ModificationHistoryItemDto historyItemDto, ModificationHistoryDto history)
    {
        var i = historyItemDto.ToDbHistoryItemInner();
        i.HistoryEntryType = historyItemDto.HistoryEntryType.ToString();
        i.HistoryId = history.EntityId;
        return i;
    }

    [MapperIgnoreTarget(nameof(DbModificationHistoryItem.HistoryEntryType))]
    [MapperIgnoreSource(nameof(ModificationHistoryItemDto.HistoryEntryType))]
    [MapperIgnoreTarget(nameof(DbModificationHistoryItem.HistoryId))]
    [MapperIgnoreTarget(nameof(DbModificationHistoryItem.History))]
    internal static partial DbModificationHistoryItem ToDbHistoryItemInner(
        this ModificationHistoryItemDto historyItemDto);
}