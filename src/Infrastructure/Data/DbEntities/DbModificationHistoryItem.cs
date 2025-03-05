using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure.Constants;

namespace Infrastructure.Data.DbEntities;

[Table("HistoryItems")]
public class DbModificationHistoryItem : DbEntityWithId
{
    [ForeignKey(nameof(History))]
    public Guid HistoryId { get; set; }
    
    public DbModificationHistory? History { get; set; }
    
    public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.UtcNow;
    [MaxLength(StringLengths.Largest)]
    public string? Message { get; set; }
    [MaxLength(StringLengths.Medium)]
    public string HistoryEntryType { get; set; } = Domain.Enums.HistoryEntryType.Unknown.ToString();

    public DbModificationHistoryItem WithoutRelatedEntites()
    {
        return new DbModificationHistoryItem()
        {
            HistoryId = HistoryId,
            Timestamp = Timestamp,
            Message = Message,
            HistoryEntryType = HistoryEntryType,
            EntityId = EntityId
        };
    }

    public override void UpdateToTarget(DbEntityWithId target)
    {
      if(target is not DbModificationHistoryItem historyItem) return;
      if (this.HistoryEntryType != historyItem.HistoryEntryType)
      {
        this.HistoryEntryType = historyItem.HistoryEntryType;
      }

      if (this.Message != historyItem.Message)
      {
        this.Message = historyItem.Message;
      }

      if (this.Timestamp != historyItem.Timestamp)
      {
        this.Timestamp = historyItem.Timestamp;
      }
    }
}
