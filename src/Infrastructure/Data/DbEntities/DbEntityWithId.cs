using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.DbEntities;

[PrimaryKey(nameof(EntityId))]
public class DbEntityWithId
{
    [Key] 
    public Guid EntityId { get; set; } = Guid.NewGuid();

    [NotMapped] 
    [MapperIgnore]
    public bool IsNewEntity { get; set; } = false;


    public virtual void UpdateToTarget(DbEntityWithId target)
    {
      
    }
}
