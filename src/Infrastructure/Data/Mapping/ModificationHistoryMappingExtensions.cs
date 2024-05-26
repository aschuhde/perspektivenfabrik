using Domain.Entities;
using Infrastructure.Data.DbEntities;

namespace Infrastructure.Data.Mapping;


public static partial class MappingExtensions
{
    public static partial ModificationHistoryDto ToHistory(this DbModificationHistory dbHistory);
    
    public static partial DbModificationHistory ToDbHistory(this ModificationHistoryDto historyDto);
    
    internal static DbModificationHistoryConnection ToDbModificationHistoryConnection(this ModificationHistoryDto historyDto)
    {
        return new DbModificationHistoryConnection()
        {
            HistoryId = historyDto.EntityId
        };
    }
    internal static ModificationHistoryDto ToModificationHistory(this DbModificationHistoryConnection history)
    {
        return history.History!.ToHistory();
    }
}