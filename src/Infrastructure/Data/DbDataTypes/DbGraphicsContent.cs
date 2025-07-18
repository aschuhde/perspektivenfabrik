using System.ComponentModel.DataAnnotations;
using Infrastructure.Constants;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DbDataTypes;

[Owned]
public sealed class DbGraphicsContent
{
    public required byte[] Content { get; set; }
    public required int? Width { get; set; }
    public required int? Height { get; set; }
    [MaxLength(StringLengths.Medium)]
    public required string? MimeType { get; set; }
    [MaxLength(StringLengths.Small)]
    public required string? FileExtension { get; set; }

    public void Update(DbGraphicsContent graphicsSpecificationContent)
    {
      if (this.Content != graphicsSpecificationContent.Content)
      {
        this.Content = graphicsSpecificationContent.Content;
      }
      if (this.Width != graphicsSpecificationContent.Width)
      {
          this.Width = graphicsSpecificationContent.Width;
      }
      if (this.Height != graphicsSpecificationContent.Height)
      {
          this.Height = graphicsSpecificationContent.Height;
      }
      if (this.MimeType != graphicsSpecificationContent.MimeType)
      {
          this.MimeType = graphicsSpecificationContent.MimeType;
      }
      if (this.FileExtension != graphicsSpecificationContent.FileExtension)
      {
          this.FileExtension = graphicsSpecificationContent.FileExtension;
      }
    }
}
