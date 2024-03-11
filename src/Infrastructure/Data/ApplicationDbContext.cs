using Infrastructure.Data.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public required DbSet<DbUser> Users { get; set; }
    public required DbSet<DbAccessPolicy> AccessPolicies { get; set; }
    public required DbSet<DbUserAccess> UserAccesses { get; set; }
    public required DbSet<DbUserRefreshTokens> UserRefreshTokens { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
