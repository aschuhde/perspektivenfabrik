using Application.Services;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Data.DbEntities;
using Infrastructure.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public sealed class UserDataService(ApplicationDbContext dbContext) : IUserDataService
{
    public async Task<User[]> GetAllActiveUsers(CancellationToken cancellationToken = default)
    {
        return await ToUsers(dbContext.Users.Where(x => x.Active)).ToArrayAsync(cancellationToken: cancellationToken);
    }
    
    public async Task<User?> GetActiveUserByEMail(string email, CancellationToken cancellationToken = default)
    {
        return await ToUsers(dbContext.Users.Where(x => x.Active &&
                                                        x.Email.ToLower() == email.ToLower())).FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }
    
    public async Task<User?> GetActiveUserById(Guid userId, CancellationToken cancellationToken = default)
    {
        return await ToUsers(dbContext.Users.Where(x => x.Active &&
                                                        x.EntityId == userId)).FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }

    private static IQueryable<User> ToUsers(IQueryable<DbUser> query)
    {
        return query.Select(x => new User
        {
            EntityId = default,
            CreatedOn = default,
            CreatedBy = null,
            LastModifiedOn = default,
            LastModifiedBy = null,
            History = null,
            Firstname = "null",
            Lastname = "null",
            Email = "null",
            ConnectedOrganizations = new OrganizationConnection[]
            {
            },
            PasswordHash = "null"
        }); //x.ToUser());
    }
}
