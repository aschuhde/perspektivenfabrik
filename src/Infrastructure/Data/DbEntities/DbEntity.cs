using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DbEntities;


public class DbEntity : DbEntityWithId
{
    public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.UtcNow;
    public DbEntityPersonCreatedByConnection? CreatedBy { get; set; }
    public DateTimeOffset LastModifiedOn { get; set; } = DateTimeOffset.UtcNow;
    public DbEntityPersonLastModifiedByConnection? LastModifiedBy { get; set; }
    public DbModificationHistoryConnection? History { get; set; }

    public override void UpdateToTarget(DbEntityWithId target)
    {
      if(target is not DbEntity entity) return;
      if (this.CreatedOn != entity.CreatedOn)
      {
        this.CreatedOn = entity.CreatedOn;
      }
      if (this.LastModifiedOn != entity.LastModifiedOn)
      {
        this.LastModifiedOn = entity.LastModifiedOn;
      }
      base.UpdateToTarget(target);
    }
}

[Owned]
public sealed class DbEntityPersonCreatedByConnection
{
    [ForeignKey(nameof(PersonId))]
    public DbPerson? Person { get; set; }
    [ForeignKey(nameof(Person))]
    public Guid PersonId { get; set; }
}

[Owned]
public sealed class DbEntityPersonLastModifiedByConnection
{
    [ForeignKey(nameof(PersonId))]
    public DbPerson? Person { get; set; }
    [ForeignKey(nameof(Person))]
    public Guid PersonId { get; set; }
}

[Owned]
public sealed class DbModificationHistoryConnection
{
    public DbModificationHistory? History { get; set; }
    [ForeignKey(nameof(History))]
    public Guid? HistoryId { get; init; }

    public DbModificationHistoryConnection WithoutRelatedEntites()
    {
      return new DbModificationHistoryConnection() { HistoryId = HistoryId, };
    }
}
