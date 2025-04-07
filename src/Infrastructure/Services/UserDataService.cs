using Application.Services;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Data.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public sealed class UserDataService(ApplicationDbContext dbContext) : IUserDataService
{
    public async Task<UserDto[]> GetAllActiveUsers(CancellationToken cancellationToken = default)
    {
        return await GetUser(await dbContext.Users.AsNoTracking().Where(x => x.Active).ToArrayAsync(cancellationToken), cancellationToken);
    }
    
    public async Task<UserDto?> GetActiveUserByEMail(string email, CancellationToken cancellationToken = default)
    {
        return (await GetUser([await dbContext.Users.Where(x => x.Active &&
                                                        x.Email.ToLower() == email.ToLower()).AsNoTracking().FirstOrDefaultAsync(cancellationToken)], cancellationToken)).FirstOrDefault();
    }
    
    public async Task<UserDto?> GetActiveUserById(Guid userId, CancellationToken cancellationToken = default)
    {
        return (await GetUser([await dbContext.Users.Where(x => x.Active &&
                                                        x.EntityId == userId).AsNoTracking().FirstOrDefaultAsync(cancellationToken)], cancellationToken)).FirstOrDefault();
    }

    private async Task<UserDto[]> GetUser(DbUser?[] users, CancellationToken ct)
    {
        var userIds = users.Select(x => x?.EntityId).Where(x => x != null).ToArray();
        var roles = await dbContext.UserRoles.Where(x => userIds.Contains(x.UserId)).AsNoTracking().ToArrayAsync(ct); 
        return users.Where(x => x != null).Select(dbUser => new UserDto
        {
            EntityId = dbUser!.EntityId,
            CreatedOn = dbUser.CreatedOn,
            CreatedBy = null,
            LastModifiedOn = dbUser.LastModifiedOn,
            LastModifiedBy = null,
            History = null,
            Firstname = dbUser.Firstname,
            Lastname = dbUser.Lastname,
            Email = dbUser.Email,
            PasswordHash = dbUser.PasswordHash,
            Active = dbUser.Active,
            Roles = roles.Where(x => x.UserId == dbUser.EntityId).Select(x => x.Role).ToArray()
        }).ToArray();
    }
}
