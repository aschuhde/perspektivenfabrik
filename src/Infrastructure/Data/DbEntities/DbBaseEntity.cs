using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DbEntities;

[PrimaryKey(nameof(EntityId))]
public class DbBaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EntityIndex { get; init; }

    [Key] public Guid EntityId { get; init; } = Guid.NewGuid();
    
    public DateTimeOffset CreatedOn { get; init; } = DateTimeOffset.UtcNow;
    public DbUser? CreatedBy { get; init; }
    public bool Active { get; init; } = true;
}
