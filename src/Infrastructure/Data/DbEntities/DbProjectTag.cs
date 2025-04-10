using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DbEntities;

[Table("ProjectTags")]
public sealed class DbProjectTag : DbEntityWithId
{
    public required string TagName { get; set; }

    public override void UpdateToTarget(DbEntityWithId target)
    {
      if(target is not DbProjectTag projectTag) return;
      if(this.TagName != projectTag.TagName)
      {
        this.TagName = projectTag.TagName;
      }
      
    }
}

[Table("ProjectTagConnections")]
public sealed class DbProjectTagConnection : DbEntityWithId
{
    [ForeignKey(nameof(Project))]
    public required Guid ProjectId { get; init; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public DbProject? Project { get; init; }
    [ForeignKey(nameof(ProjectTag))]
    public required Guid ProjectTagId { get; init; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public DbProjectTag? ProjectTag { get; init; }
}
