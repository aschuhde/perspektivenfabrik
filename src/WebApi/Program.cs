using Application;
using FastEndpoints;
using FastEndpoints.Swagger;
using Infrastructure;
using Infrastructure.Data;
using Serilog;
using WebApi;
using WebApi.Common;
using WebApi.Constants;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddConfiguration(builder.Environment);
builder.AddLogging();

if (!builder.Configuration.IsInCodeGenerationMode())
{
    builder.Services.AddApplication();
    builder.Services.AddInfrastructure(builder.Configuration, builder.Environment);
}
builder.Services.AddWebApi(builder.Configuration);

var app = builder.Build();
if (!builder.Configuration.IsInCodeGenerationMode())
{
    app.UseSerilogRequestLogging();
    await app.InitializeDatabaseAsync();
}

app.UseCors(CorsPolicies.AllowAll);

if (!builder.Configuration.IsInCodeGenerationMode())
{
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseHealthChecks("/health");
}

app.UseFastEndpoints();
app.UseSwaggerGen();
app.Run();
