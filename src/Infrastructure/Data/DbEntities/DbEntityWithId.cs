using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DbEntities;

[PrimaryKey(nameof(EntityId))]
public class DbEntityWithId
{
    [Key] 
    public Guid EntityId { get; init; } = Guid.NewGuid();
}