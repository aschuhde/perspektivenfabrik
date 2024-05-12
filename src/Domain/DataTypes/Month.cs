namespace Domain.DataTypes;

public sealed class Month
{
    public required int MonthFromOneToTwelve { get; init; }
    public required Year Year { get; init; }
}