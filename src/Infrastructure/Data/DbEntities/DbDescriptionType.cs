using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure.Data.DbDataTypes;

namespace Infrastructure.Data.DbEntities;

[Table("DescriptionTypes")]
public sealed class DbDescriptionType : DbEntityWithId
{
    public required string Name { get; set; }
    public required DbFormattedTitle DescriptionTitle { get; set; }

    public override void UpdateToTarget(DbEntityWithId target)
    {
      if(target is not DbDescriptionType descriptionType) return;
      if (this.Name != descriptionType.Name)
      {
        this.Name = descriptionType.Name;
      }

      this.DescriptionTitle.Update(descriptionType.DescriptionTitle);
    }
}
