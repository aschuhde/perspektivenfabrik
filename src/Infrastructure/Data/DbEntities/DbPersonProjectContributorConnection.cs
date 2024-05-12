using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.DbEntities;

[Table("PersonProjectContributorConnections")]
public sealed class DbPersonProjectContributorConnection : DbEntityWithId
{
    [ForeignKey(nameof(Project))]
    public required Guid ProjectId { get; init; }
    public DbProject? Project { get; init; }
    [ForeignKey(nameof(Person))]
    public required Guid PersonId { get; init; }
    public DbPerson? Person { get; init; }
}