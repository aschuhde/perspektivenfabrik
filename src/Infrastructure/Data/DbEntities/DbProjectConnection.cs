using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DbEntities;

[Table("ProjectConnections")]
public sealed class DbProjectConnection : DbEntityWithId
{
    public required Guid ProjectId { get; init; }
    [ForeignKey(nameof(ProjectId))]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public DbProject? Project { get; set; }
    public required ProjectConnectionType Type { get; init; }
    
    [ForeignKey(nameof(RelatedProject))]
    public required Guid RelatedProjectId { get; init; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    
    public DbProject? RelatedProject { get; set; }
}
