using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using WebApi;

namespace Application.FunctionalTests;

public sealed class CustomWebApplicationFactory : WebApplicationFactory<IAssemblyMarker>
{
    private string ExecutionDirectory => Directory.GetCurrentDirectory();
    private string GetConfigurationPath(string filename) => Path.Combine(ExecutionDirectory, filename);
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            
        });
        builder.ConfigureAppConfiguration(builder =>
        {
            
        });
    }
    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.ConfigureHostConfiguration(configurationBuilder =>
        {
            if (configurationBuilder is not IConfiguration configuration)
                throw new Exception("configurationBuilder needs to implement IConfiguration");
            
            configurationBuilder.AddJsonFile(GetConfigurationPath("appsettings.test.user.json"), optional:true);
            ConfigurationUpdated(configuration);
        });
        return base.CreateHost(builder);
    }
    private void ConfigurationUpdated(IConfiguration configurationManager)
    {
        foreach (var keyValuePair in configurationManager.GetSection("EnvironmentVariables").GetChildren())
        {
            if (keyValuePair.Value == null)
                continue;
            Environment.SetEnvironmentVariable(keyValuePair.Key, keyValuePair.Value);
        }
        foreach (var keyValuePair in configurationManager.GetSection("Configuration").AsEnumerable())
        {
            if (keyValuePair.Value == null)
                continue;
            Environment.SetEnvironmentVariable($"{Configuration.EnvironmentConfigurationOverridePrefix}{keyValuePair.Key.Replace(":", "__")}", keyValuePair.Value);
        }
        foreach (var keyValuePair in configurationManager.GetSection("ConfigurationOverrides").AsEnumerable())
        {
            if (keyValuePair.Value == null)
                continue;
            Environment.SetEnvironmentVariable($"{Configuration.EnvironmentConfigurationOverridePrefix}{keyValuePair.Key.Replace(":", "__")}", keyValuePair.Value);
        }
    }
    //
    // private void ConfigurationUpdated(IConfiguration configurationManager)
    // {
    //     Environment.SetEnvironmentVariable($"4CCONFIG_{ConnectionStringKeyName.Replace(":", "__")}", connectionString);
    //     
    //     foreach (var keyValuePair in configurationManager.AsEnumerable())
    //     {
    //         if (keyValuePair.Value == null)
    //             continue;
    //         Environment.SetEnvironmentVariable($"4CCONFIGOVERRIDE_{keyValuePair.Key.Replace(":", "__")}", keyValuePair.Value);
    //     }
    // }
}