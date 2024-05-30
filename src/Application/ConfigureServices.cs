using Application.PostProject.PostProject;
using Application.Services;
using Application.Validators;
using Domain.Entities;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ConfigureServices
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<JwtAuthenticationDataService>();
        services.AddScoped<IValidator<PostProjectRequest>, PostProjectRequestValidator>();
    }
}
