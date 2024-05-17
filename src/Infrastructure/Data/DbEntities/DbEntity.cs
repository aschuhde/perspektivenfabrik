using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DbEntities;


public class DbEntity : DbEntityWithId
{
    public DateTimeOffset CreatedOn { get; init; } = DateTimeOffset.UtcNow;
    public DbEntityPersonCreatedByConnection? CreatedBy { get; init; }
    public DateTimeOffset LastModifiedOn { get; init; } = DateTimeOffset.UtcNow;
    public DbEntityPersonLastModifiedByConnection? LastModifiedBy { get; init; }
    public bool Active { get; init; } = true;
    public DbModificationHistoryConnection? History { get; init; }

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
}