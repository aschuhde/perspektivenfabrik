namespace WebApi.Common;

public static class ConfigurationExtensions
{
    public static bool IsInCodeGenerationMode(this IConfiguration configuration) =>
        configuration.GetValue<bool?>("CodeGenerationMode") == true;

}
