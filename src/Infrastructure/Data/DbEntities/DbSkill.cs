using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.DbEntities;

[Table("Skill")]
public class DbSkill : DbEntityWithId
{
    [MaxLength(Constants.StringLengths.Medium)]
    public required string Name { get; set; }
    
    public override void UpdateToTarget(DbEntityWithId target)
    {
        if( target is not DbSkill skill) return;
        if (this.Name != skill.Name)
        {
            this.Name = skill.Name;
        }
        base.UpdateToTarget(target);
    }
}