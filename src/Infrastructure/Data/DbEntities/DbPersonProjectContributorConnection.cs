using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DbEntities;

[Table("PersonProjectContributorConnections")]
public sealed class DbPersonProjectContributorConnection : DbEntityWithId
{
    [ForeignKey(nameof(Project))]
    public required Guid ProjectId { get; init; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public DbProject? Project { get; init; }
    [ForeignKey(nameof(Person))]
    public required Guid PersonId { get; init; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public DbPerson? Person { get; init; }
}
