using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.DbEntities;


public class DbEntity : DbEntityWithId
{
    public DateTimeOffset CreatedOn { get; init; } = DateTimeOffset.UtcNow;
    [ForeignKey(nameof(CreatedBy))]
    public Guid? CreatedById { get; init; }
    public DbPerson? CreatedBy { get; init; }
    public DateTimeOffset LastModifiedOn { get; init; } = DateTimeOffset.UtcNow;
    public DbPerson? LastModifiedBy { get; init; }
    [ForeignKey(nameof(LastModifiedBy))]
    public Guid? LastModifiedById { get; init; }
    public bool Active { get; init; } = true;
    public DbModificationHistory? History { get; init; }
    [ForeignKey(nameof(DbModificationHistory))]
    public Guid? HistoryId { get; init; }
}
