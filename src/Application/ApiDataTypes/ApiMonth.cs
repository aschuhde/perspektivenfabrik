namespace Application.ApiDataTypes;

public sealed class ApiMonth
{
    public required int MonthFromOneToTwelve { get; init; }
    public required ApiYear Year { get; init; }
}