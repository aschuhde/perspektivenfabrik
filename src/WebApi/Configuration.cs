using Infrastructure;
using Serilog;
using WebApi.Common;

namespace WebApi;

public static class Configuration
{

    public static void AddConfiguration(this ConfigurationManager configurationManager,
        IHostEnvironment hostEnvironment)
    {
        configurationManager.AddJsonFile("appsettings.json", optional: true);
        configurationManager.AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", optional: true);

        configurationManager.AddEnvironmentVariables(prefix: "CONFIG_");
        
        const string connectionStringKeyName = "ConnectionStrings:";
        var connectionString = "";
        if (!configurationManager.IsInCodeGenerationMode()){
            connectionString = configurationManager.GetDefaultConnectionString();
            //configurationManager.AddSqlServer(connectionString);
        }

        configurationManager.AddJsonFile($"appsettings.override.json", optional: true);

        // there can be the need for some environment variables to override the sql configuration.
        // for example: two instances running with the same database want to have different log levels
        configurationManager.AddEnvironmentVariables(prefix: "CONFIG_OVERRIDE_");

        // set the connection string to the previous value for the case that the sql server updates the connection string 
        configurationManager[connectionStringKeyName] = connectionString;

        //load environment variables configured in the EnvironmentVariables section
        foreach (var variableDef in configurationManager.GetSection("EnvironmentVariable").GetChildren()
                     .Select(x => new KeyValuePair<string, string?>(x.Key, x.Value)))
        {
            if (variableDef.Value == null)
                continue;
            Environment.SetEnvironmentVariable(variableDef.Key, variableDef.Value);
        }

        foreach (var keyValuePair in configurationManager.AsEnumerable())
        {
            if (keyValuePair.Value == null)
                continue;
            if (keyValuePair.Value == ".remove")
            {
                configurationManager[keyValuePair.Key] = null;
                continue;
            }

            configurationManager[keyValuePair.Key] = Environment.ExpandEnvironmentVariables(keyValuePair.Value);
        }
    }
    
    public static void AddLogging(this WebApplicationBuilder builder)
    {
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration).CreateLogger(); 
        
        builder.Host.UseSerilog();
    }
}
