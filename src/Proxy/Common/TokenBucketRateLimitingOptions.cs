namespace Proxy.Common;

public sealed class TokenBucketRateLimitingOptions
{
    public const string ConfigurationKey = "RateLimiting";
    
    public int TokenLimit { get; init; }
    public int QueueLimit { get; init; }
    public int ReplenishmentPeriodMinutes { get; init; }
    public int TokensPerPeriod { get; init; }
}