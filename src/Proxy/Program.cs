using System.Threading.RateLimiting;
using Common;
using Proxy.Common;
using Proxy.Middlewares;

var builder = WebApplication.CreateBuilder(args);

foreach (var keyValuePair in builder.Configuration.AsEnumerable())
{
    if (keyValuePair.Value == null)
        continue;
    builder.Configuration[keyValuePair.Key] = Environment.ExpandEnvironmentVariables(keyValuePair.Value);
}

var rateLimitingOptions = ThrowIf.Null(builder.Configuration.GetSection(TokenBucketRateLimitingOptions.ConfigurationKey).Get<TokenBucketRateLimitingOptions>());

builder.Services.AddRateLimiter(rateLimiterOptions =>
{
    rateLimiterOptions.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
    
    rateLimiterOptions.AddPolicy("fixed-by-ip", httpContext =>
        RateLimitPartition.GetTokenBucketLimiter(
            partitionKey: httpContext.Connection.RemoteIpAddress?.ToString(),
            factory: _ => new TokenBucketRateLimiterOptions()
            {
                TokenLimit = rateLimitingOptions.TokenLimit,
                QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
                QueueLimit = rateLimitingOptions.QueueLimit,
                ReplenishmentPeriod = TimeSpan.FromMinutes(rateLimitingOptions.ReplenishmentPeriodMinutes),
                TokensPerPeriod = rateLimitingOptions.TokensPerPeriod,
                AutoReplenishment = true
            }));
});
builder.Services.AddReverseProxy().LoadFromConfig(builder.Configuration.GetSection("Proxy"));
var app = builder.Build();
app.UseGlobalAccessMiddlewareIfEnabled(app.Configuration);
app.MapReverseProxy();
app.UseHttpsRedirection();
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.Run();
