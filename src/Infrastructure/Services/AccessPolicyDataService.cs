using Application.Services;
using Domain.Entities;
using Infrastructure.Common;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class AccessPolicyDataService(ApplicationDbContext dbContext) : IAccessPolicyDataService
{
    public async Task<AccessPolicy[]> GetReadPolicies(Guid userId, CancellationToken cancellationToken = default)
    {
        return await dbContext.UserAccesses.Where(x => x.UserId == userId && x.PermissionKey == PermissionKey.Read).Select(x => new AccessPolicy()
        {
            AccessPolicyId = x.AccessPolicyId
        }).ToArrayAsync(cancellationToken: cancellationToken);
    }

    public async Task<AccessPolicy[]> GetWritePolicies(Guid userId, CancellationToken cancellationToken = default)
    {
        return await dbContext.UserAccesses.Where(x => x.UserId == userId && x.PermissionKey == PermissionKey.Write).Select(x => new AccessPolicy()
        {
            AccessPolicyId = x.AccessPolicyId
        }).ToArrayAsync(cancellationToken: cancellationToken);
    }
}
