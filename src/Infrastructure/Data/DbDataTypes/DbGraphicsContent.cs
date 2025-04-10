using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DbDataTypes;

[Owned]
public sealed class DbGraphicsContent
{
    public required byte[] Content { get; set; }

    public void Update(DbGraphicsContent graphicsSpecificationContent)
    {
      if (this.Content != graphicsSpecificationContent.Content)
      {
        this.Content = graphicsSpecificationContent.Content;
      }
    }
}
