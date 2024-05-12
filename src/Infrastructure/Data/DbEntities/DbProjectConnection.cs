using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Infrastructure.Data.DbEntities;

[Table("ProjectConnections")]
public sealed class DbProjectConnection : DbEntityWithId
{
    public required Guid ProjectId { get; init; }
    [ForeignKey(nameof(ProjectId))]
    public DbProject? Project { get; init; }
    public required ProjectConnectionType Type { get; init; }
    
    [ForeignKey(nameof(RelatedProject))]
    public required Guid RelatedProjectId { get; init; }
    
    public DbProject? RelatedProject { get; init; }
}