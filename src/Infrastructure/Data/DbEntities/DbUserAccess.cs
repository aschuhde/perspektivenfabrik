using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure.Constants;

namespace Infrastructure.Data.DbEntities;

[Table("UserAccesses")]
public class DbUserAccess : DbBaseEntity
{
    [ForeignKey(nameof(DbAccessPolicy))]
    public required Guid AccessPolicyId { get; init; }
    [ForeignKey(nameof(DbUser))]
    public required Guid UserId { get; init; }
    public required DbAccessPolicy DbAccessPolicy { get; init; }
    public required DbUser DbUser { get; init; }
    
    [MaxLength(StringLengths.Small)]
    public required string PermissionKey { get; init; }
}
