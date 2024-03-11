using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using WebApi;

namespace Application.FunctionalTests;

public class CustomWebApplicationFactory : WebApplicationFactory<IAssemblyMarker>
{

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            
        });
    }
}