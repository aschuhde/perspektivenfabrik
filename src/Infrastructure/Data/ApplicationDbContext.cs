using Infrastructure.Data.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public required DbSet<DbUser> Users { get; init; }
    public required DbSet<DbUserRefreshTokens> UserRefreshTokens { get; init; }
    public required DbSet<DbProject> Projects { get; init; }
    public required DbSet<DbOrganization> Organizations { get; init; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
