using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.DbEntities;

[Table("Histories")]
public class DbModificationHistory : DbEntityWithId
{
    public List<DbModificationHistoryItem>? HistoryItems { get; set; }
}