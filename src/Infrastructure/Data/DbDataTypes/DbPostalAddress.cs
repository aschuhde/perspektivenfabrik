using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DbDataTypes;

[Owned]
public sealed class DbPostalAddress
{
    [MaxLength(Constants.StringLengths.Medium)]
    public required string AddressText { get; set; }
    [MaxLength(Constants.StringLengths.Medium)]
    public required string AddressDisplayName { get; set; }

    public void Update(DbPostalAddress targetEntity)
    {
      if (AddressText != targetEntity.AddressText)
      {
        AddressText = targetEntity.AddressText;
      }
      if (AddressDisplayName != targetEntity.AddressDisplayName)
      {
        AddressDisplayName = targetEntity.AddressDisplayName;
      }
    }
}
