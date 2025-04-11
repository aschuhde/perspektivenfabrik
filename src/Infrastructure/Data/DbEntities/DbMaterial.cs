using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.DbEntities;

[Table("Material")]
public class DbMaterial : DbEntityWithId
{
    [MaxLength(Constants.StringLengths.Medium)]
    public required string Name { get; set; }
    
    public override void UpdateToTarget(DbEntityWithId target)
    {
        if( target is not DbMaterial material) return;
        if (this.Name != material.Name)
        {
            this.Name = material.Name;
        }
        base.UpdateToTarget(target);
    }
}