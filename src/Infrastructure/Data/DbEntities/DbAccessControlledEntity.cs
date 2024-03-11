using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.DbEntities;

public class DbAccessControlledEntity : DbBaseEntity
{
    [ForeignKey(nameof(DbAccessPolicy))]
    public required Guid AccessPolicyId { get; init; }
    
    public DbAccessPolicy? DbAccessPolicy { get; init; }
}
