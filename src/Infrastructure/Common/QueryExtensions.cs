using Infrastructure.Data.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Common;

public static class QueryExtensions
{
    public static IQueryable<T> WhereUserHasReadAccess<T>(this IQueryable<T> query, Guid userId)
        where T : DbAccessControlledEntity => query.WhereUserHasAccess(userId, PermissionKey.Read);

    public static IQueryable<T> WhereUserHasWriteAccess<T>(this IQueryable<T> query, Guid userId)
        where T : DbAccessControlledEntity => query.WhereUserHasAccess(userId, PermissionKey.Write);

    public static IQueryable<T> WhereUserHasAccess<T>(this IQueryable<T> query, Guid userId, string permissionKey)
        where T : DbAccessControlledEntity => query.Include(x => x.DbAccessPolicy)
        .ThenInclude(x => x!.UserAccesses.Where(y => y.UserId == userId && y.PermissionKey == permissionKey))
        .Where(x => x.DbAccessPolicy!.UserAccesses.Count != 0);
}
