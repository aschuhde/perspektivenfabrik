using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DbDataTypes;

[Owned]
public sealed class DbRegion
{
    [MaxLength(Constants.StringLengths.Medium)]
    public required string RegionName { get; set; }
    [MaxLength(Constants.StringLengths.Medium)]
    public required string AddressText { get; set; }

    public void Update(DbRegion targetEntityRegion)
    {
      if (this.RegionName != targetEntityRegion.RegionName)
      {
        this.RegionName = targetEntityRegion.RegionName;
      }
      if (this.AddressText != targetEntityRegion.AddressText)
      {
          this.AddressText = targetEntityRegion.AddressText;
      }
    }
}
