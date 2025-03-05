using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DbDataTypes;

[Owned]
public sealed class DbYear
{
    public required int YearNumber { get; set; }

    public void Update(DbYear dbYear)
    {
      if (dbYear.YearNumber != YearNumber)
      {
        YearNumber = dbYear.YearNumber;
      }
    }
}
