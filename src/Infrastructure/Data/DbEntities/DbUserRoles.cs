using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.DbEntities;

[Table("UserRoles")]
public sealed class DbUserRoles : DbEntity
{
    [ForeignKey(nameof(DbUser))]
    public required Guid UserId { get; init; }
    
    [MaxLength(Constants.StringLengths.Medium)]
    public required string Role { get; set; }
    
    public override void UpdateToTarget(DbEntityWithId target)
    {
        if(target is not DbUserRoles userRole) return;
        if (this.Role != userRole.Role)
        {
            this.Role = userRole.Role;
        }

        base.UpdateToTarget(target);
    }
}
