using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DbDataTypes;

[Owned]
public sealed class DbUrl
{
    [MaxLength(Constants.StringLengths.Medium)]
    public required string RawUrl { get; set; }

    public void Update(DbUrl targetEntity)
    {
      if (this.RawUrl != targetEntity.RawUrl)
      {
        this.RawUrl = targetEntity.RawUrl;
      }
    }
}
