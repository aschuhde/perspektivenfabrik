using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure.Data.DbDataTypes;
using Microsoft.EntityFrameworkCore;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.DbEntities;

[Table("DescriptionImage")]
public class DbProjectImage : DbEntityWithId
{
    [ForeignKey(nameof(Project))]
    public required Guid ProjectId { get; set; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    [MapperIgnore]
    public DbProject? Project { get; set; }
    
    public required DbGraphicsContent Content { get; set; }
    public DbGraphicsContent? Thumbnail { get; set; }
    
    public override void UpdateToTarget(DbEntityWithId target)
    {
        if(target is not DbProjectImage projectImage) return;
        if (this.ProjectId != projectImage.ProjectId)
        {
            this.ProjectId = projectImage.ProjectId;
        }
        this.Content.Update(projectImage.Content);
        if (projectImage.Thumbnail != null && this.Thumbnail != null)
        {
            this.Thumbnail?.Update(projectImage.Thumbnail);
        }else if(this.Thumbnail != null)
        {
            this.Thumbnail = null;
        }else if (this.Thumbnail == null)
        {
            this.Thumbnail = projectImage.Thumbnail;
        }
    }
}