using Infrastructure.Data.DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data;

public static class InitializerExtensions
{
    public static async Task InitializeDatabaseAsync(this IHost app)
    {
        using var scope = app.Services.CreateScope();

        var initializer = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitializer>();

        await initializer.InitializeAsync();

        await initializer.SeedAsync();
    }
}

public sealed class ApplicationDbContextInitializer(
    ILogger<ApplicationDbContextInitializer> logger,
    ApplicationDbContext context)
{
    public async Task InitializeAsync()
    {
        try
        {
            await context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while initializing the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // #if DEBUG
        //         await using var transaction = await context.Database.BeginTransactionAsync();
        //         try
        //         {
        //             await context.SaveChangesAsync();
        //             context.Users.Add(new DbUser()
        //             {
        //                 Email = "root@test.test",
        //                 Firstname = "root",
        //                 Lastname = "test",
        //                 PasswordHash = "test",
        //                 History = null,
        //                 Active = true
        //             });
        //             await context.SaveChangesAsync();
        //             await transaction.CommitAsync();
        //         }
        //         catch
        //         {
        //             await transaction.RollbackAsync();
        //             throw;
        //         }
        // #endif
        //
        await Task.Yield();
    }
}
