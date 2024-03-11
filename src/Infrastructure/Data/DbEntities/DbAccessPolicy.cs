using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.DbEntities;

[Table("AccessPolicies")]
public class DbAccessPolicy : DbBaseEntity
{
    public List<DbUserAccess> UserAccesses { get; init; } = [];
}
