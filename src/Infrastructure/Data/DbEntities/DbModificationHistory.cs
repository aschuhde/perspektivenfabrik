using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DbEntities;

[Table("Histories")]
public class DbModificationHistory : DbEntityWithId
{
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public List<DbModificationHistoryItem>? HistoryItems { get; set; }

    public DbModificationHistory WithoutRelatedEntites()
    {
      return new DbModificationHistory() { EntityId = this.EntityId };
    }

    public override void UpdateToTarget(DbEntityWithId target)
    {
      if(target is not DbModificationHistory history) return;

      this.HistoryItems =
        this.HistoryItems?.GetUpdateConnections(history.HistoryItems, x => x.HistoryId, x => x.EntityId) ??
        history.HistoryItems;
      
      base.UpdateToTarget(target);
    }
}
