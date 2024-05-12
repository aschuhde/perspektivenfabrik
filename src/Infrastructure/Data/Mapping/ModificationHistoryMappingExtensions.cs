using Domain.Entities;
using Infrastructure.Data.DbEntities;

namespace Infrastructure.Data.Mapping;


public static partial class MappingExtensions
{
    public static partial ModificationHistory ToHistory(this DbModificationHistory dbHistory);
    
    public static partial DbModificationHistory ToDbHistory(this ModificationHistory history);
    
    internal static DbModificationHistoryConnection ToDbModificationHistoryConnection(this ModificationHistory history)
    {
        return new DbModificationHistoryConnection()
        {
            HistoryId = history.EntityId
        };
    }
    internal static ModificationHistory ToModificationHistory(this DbModificationHistoryConnection history)
    {
        return history.History!.ToHistory();
    }
}