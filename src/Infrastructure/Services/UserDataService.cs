using Application.Services;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Data.DbEntities;
using Infrastructure.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public sealed class UserDataService(ApplicationDbContext dbContext) : IUserDataService
{
    public async Task<UserDto[]> GetAllActiveUsers(CancellationToken cancellationToken = default)
    {
        return await ToUsers(dbContext.Users.Where(x => x.Active)).ToArrayAsync(cancellationToken: cancellationToken);
    }
    
    public async Task<UserDto?> GetActiveUserByEMail(string email, CancellationToken cancellationToken = default)
    {
        return await ToUsers(dbContext.Users.Where(x => x.Active &&
                                                        x.Email.ToLower() == email.ToLower())).FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }
    
    public async Task<UserDto?> GetActiveUserById(Guid userId, CancellationToken cancellationToken = default)
    {
        return await ToUsers(dbContext.Users.Where(x => x.Active &&
                                                        x.EntityId == userId)).FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }

    private static IQueryable<UserDto> ToUsers(IQueryable<DbUser> query)
    {
        return query.Select(x => new UserDto
        {
            EntityId = x.EntityId,
            CreatedOn = x.CreatedOn,
            CreatedBy = null,
            LastModifiedOn = x.LastModifiedOn,
            LastModifiedBy = null,
            History = null,
            Firstname = x.Firstname,
            Lastname = x.Lastname,
            Email = x.Email,
            // todo: ConnectedOrganizations = new OrganizationConnectionDto[]
            // {
            // },
            PasswordHash = x.PasswordHash,
            Active = x.Active
        }); //x.ToUser());
    }
}
