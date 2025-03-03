using Application.PostProject.PostProject;
using Application.PutProject.PutProject;
using Application.Services;
using Application.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ConfigureServices
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<JwtAuthenticationDataService>();
        services.AddScoped<IValidator<PostProjectRequest>, PostProjectRequestValidator>();
        services.AddScoped<IValidator<PutProjectRequest>, PutProjectRequestValidator>();
        services.AddScoped<IUserAccessService, UserAccessService>();
    }
}
