using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DbDataTypes;

[Owned]
public sealed class DbMonth
{
    public required int MonthFromOneToTwelve { get; set; }
    public required DbYear Year { get; init; }

    public void Update(DbMonth dateMonth)
    {
      if (dateMonth.MonthFromOneToTwelve != MonthFromOneToTwelve)
      {
        this.MonthFromOneToTwelve = dateMonth.MonthFromOneToTwelve;
      }
      this.Year.Update(dateMonth.Year);
    }
}
