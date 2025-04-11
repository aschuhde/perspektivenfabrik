using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.DbEntities;

[Table("Tag")]
public class DbTag : DbEntityWithId
{
    [MaxLength(Constants.StringLengths.Medium)]
    public required string Name { get; set; }
    
    public override void UpdateToTarget(DbEntityWithId target)
    {
        if( target is not DbTag tag) return;
        if (this.Name != tag.Name)
        {
            this.Name = tag.Name;
        }
        base.UpdateToTarget(target);
    }
}