using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DbEntities;


public class DbEntity : DbEntityWithId
{
    public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.UtcNow;

    [DeleteBehavior(DeleteBehavior.NoAction)]
    public DbEntityPersonCreatedByConnection? CreatedBy { get; set; }
    public DateTimeOffset LastModifiedOn { get; set; } = DateTimeOffset.UtcNow;
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public DbEntityPersonLastModifiedByConnection? LastModifiedBy { get; set; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
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
      if ( this.History?.HistoryId != entity.History?.HistoryId)
      {
        this.History = entity.History == null ? null : new DbModificationHistoryConnection()
        {
          HistoryId = entity.History.HistoryId, 
        };
      }
      if ( this.LastModifiedBy?.PersonId != entity.LastModifiedBy?.PersonId)
      {
        this.LastModifiedBy = entity.LastModifiedBy == null ? null : new DbEntityPersonLastModifiedByConnection()
        {
          PersonId = entity.LastModifiedBy.PersonId, 
        };
      }
      if ( this.CreatedBy?.PersonId != entity.CreatedBy?.PersonId)
      {
        this.CreatedBy = entity.CreatedBy == null ? null : new DbEntityPersonCreatedByConnection()
        {
          PersonId = entity.CreatedBy.PersonId, 
        };
      }
      base.UpdateToTarget(target);
    }
}

[Owned]
public sealed class DbEntityPersonCreatedByConnection
{
    [ForeignKey(nameof(PersonId))]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public DbPerson? Person { get; set; }
    [ForeignKey(nameof(Person))]
    public Guid PersonId { get; set; }
}

[Owned]
public sealed class DbEntityPersonLastModifiedByConnection
{
    [ForeignKey(nameof(PersonId))]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public DbPerson? Person { get; set; }
    [ForeignKey(nameof(Person))]
    public Guid PersonId { get; set; }
}

[Owned]
public sealed class DbModificationHistoryConnection
{
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public DbModificationHistory? History { get; set; }
    [ForeignKey(nameof(History))]
    public Guid? HistoryId { get; init; }

    public DbModificationHistoryConnection WithoutRelatedEntites()
    {
      return new DbModificationHistoryConnection() { HistoryId = HistoryId, };
    }
}
