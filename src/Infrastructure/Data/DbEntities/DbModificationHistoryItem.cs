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
    
    public DateTimeOffset Timestamp { get; init; } = DateTimeOffset.UtcNow;
    [MaxLength(StringLengths.Largest)]
    public string? Message { get; init; }
    [MaxLength(StringLengths.Medium)]
    public string HistoryEntryType { get; set; } = Domain.Enums.HistoryEntryType.Unknown.ToString();
}