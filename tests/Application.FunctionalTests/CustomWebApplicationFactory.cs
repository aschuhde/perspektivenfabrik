using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using WebApi;

namespace Application.FunctionalTests;

public class CustomWebApplicationFactory : WebApplicationFactory<IAssemblyMarker>
{

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            
        });
        builder.ConfigureAppConfiguration(builder =>
        {
            
        });
    }
    
    // protected override IHost CreateHost(IHostBuilder builder)
    // {
    //     builder.ConfigureHostConfiguration(configurationBuilder =>
    //     {
    //         if (configurationBuilder is not IConfiguration configuration)
    //             throw new Exception("configurationBuilder needs to implement IConfiguration");
    //         
    //         configurationBuilder.AddJsonFile(GetConfigurationPath("appsettings.tests.common.json"));
    //         ConfigurationUpdated(configuration, connectionString);
    //     });
    //     return base.CreateHost(builder);
    // }
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