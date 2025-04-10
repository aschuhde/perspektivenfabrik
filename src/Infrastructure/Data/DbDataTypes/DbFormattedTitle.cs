using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DbDataTypes;

[Owned]
public sealed class DbFormattedTitle
{
    [MaxLength(Constants.StringLengths.Large)]
    public required string RawContentString { get; set; }

    public void Update(DbFormattedTitle descriptionTypeDescriptionTitle)
    {
      if (this.RawContentString != descriptionTypeDescriptionTitle.RawContentString)
      {
        this.RawContentString = descriptionTypeDescriptionTitle.RawContentString;
      }
    }
}
