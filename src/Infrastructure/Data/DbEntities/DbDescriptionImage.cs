using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure.Data.DbDataTypes;
using Microsoft.EntityFrameworkCore;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.DbEntities;

[Table("DescriptionImage")]
public class DbDescriptionImage : DbEntityWithId
{
    [ForeignKey(nameof(Project))]
    public required Guid ProjectId { get; set; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    [MapperIgnore]
    public DbProject? Project { get; set; }
    
    public required DbGraphicsContent Content { get; set; }
    
    public override void UpdateToTarget(DbEntityWithId target)
    {
        if(target is not DbDescriptionImage descriptionImage) return;
        if (this.ProjectId != descriptionImage.ProjectId)
        {
            this.ProjectId = descriptionImage.ProjectId;
        }
        this.Content.Update(descriptionImage.Content);
    }
}