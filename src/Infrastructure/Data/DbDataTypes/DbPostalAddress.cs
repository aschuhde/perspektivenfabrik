using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DbDataTypes;

[Owned]
public sealed class DbPostalAddress
{
    [MaxLength(Constants.StringLengths.Medium)]
    public required string AddressLine1 { get; set; }
    [MaxLength(Constants.StringLengths.Medium)]
    public required string AddressLine2 { get; set; }
    [MaxLength(Constants.StringLengths.Medium)]
    public required string AddressLine3 { get; set; }
    [MaxLength(Constants.StringLengths.Medium)]
    public required string AddressLine4 { get; set; }
    [MaxLength(Constants.StringLengths.Medium)]
    public required string AddressLine5 { get; set; }
    [MaxLength(Constants.StringLengths.Medium)]
    public required string AddressLine6 { get; set; }

    public void Update(DbPostalAddress targetEntity)
    {
      if (AddressLine1 != targetEntity.AddressLine1)
      {
        AddressLine1 = targetEntity.AddressLine1;
      }
      if (AddressLine2 != targetEntity.AddressLine2)
      {
        AddressLine2 = targetEntity.AddressLine2;
      }
      if (AddressLine3 != targetEntity.AddressLine3)
      {
        AddressLine3 = targetEntity.AddressLine3;
      }
      if (AddressLine4 != targetEntity.AddressLine4)
      {
        AddressLine4 = targetEntity.AddressLine4;
      }
      if (AddressLine5 != targetEntity.AddressLine5)
      {
        AddressLine5 = targetEntity.AddressLine5;
      }
      if (AddressLine6 != targetEntity.AddressLine6)
      {
        AddressLine6 = targetEntity.AddressLine6;
      }
    }
}
