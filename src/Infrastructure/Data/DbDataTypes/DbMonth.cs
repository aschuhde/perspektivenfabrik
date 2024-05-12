using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DbDataTypes;

[Owned]
public sealed class DbMonth
{
    public required int MonthFromOneToTwelve { get; init; }
    public required DbYear Year { get; init; }
}