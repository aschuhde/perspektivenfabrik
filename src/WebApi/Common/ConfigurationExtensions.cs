namespace WebApi.Common;

public static class ConfigurationExtensions
{
    public static bool IsInCodeGenerationMode(this IConfiguration configuration) =>
        configuration.GetValue<bool?>("CodeGenerationMode") == true;
    
    public static bool UseAzureMonitor(this IConfiguration configuration) =>
        configuration.GetValue<bool?>("AzureMonitor:Enabled") == true;
    
    public static string? GetAzureMonitorConnectionString(this IConfiguration configuration) =>
        configuration["AzureMonitor:ConnectionString"];

}
