using Application.Services;
using Application.Tools;
using Domain.DataTypes;
using Infrastructure.Data;
using Infrastructure.Data.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public sealed class RefreshTokenRepositoryService(ApplicationDbContext dbContext) : IRefreshTokenRepositoryService
{
    private const double ExpirationHours = 24 * 30;
    private async Task AddUserRefreshTokens(Guid userId, string refreshToken, CancellationToken cancellationToken = default)
    {
        dbContext.UserRefreshTokens.Add(new DbUserRefreshTokens
        {
            RefreshToken = refreshToken,
            UserId = userId,
            AbsoluteExpirationUtc = DateTimeOffset.UtcNow.AddHours(ExpirationHours),
            Active = true
        });
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<UserRefreshToken[]> GetSavedRefreshTokens(Guid userId, CancellationToken cancellationToken = default)
    {
        var dbEntries = await dbContext.UserRefreshTokens
            .Where(x => x.Active)
            .Select(x => new
            {
                x.RefreshToken,
                x.AbsoluteExpirationUtc,
            }).ToArrayAsync(cancellationToken: cancellationToken);
        
        return dbEntries.Select(dbEntry => new UserRefreshToken()
        {
            RefreshToken = dbEntry.RefreshToken,
            AbsoluteExpirationUtc = dbEntry.AbsoluteExpirationUtc,
            ShouldBeRenewed = (dbEntry.AbsoluteExpirationUtc - DateTimeOffset.UtcNow).TotalHours < ExpirationHours / 2
        }).ToArray();
    }

    public async Task<string> GetRenewedRefreshTokenStringIfNecessary(Guid userId, CancellationToken cancellationToken = default)
    {
        var refreshTokens = await GetSavedRefreshTokens(userId, cancellationToken);
        if (refreshTokens.Length == 0 || refreshTokens.All(x => x.ShouldBeRenewed))
            return await GetRenewedRefreshTokenString(userId, cancellationToken);
        
        return refreshTokens.FirstOrDefault(x => !x.ShouldBeRenewed)!.RefreshToken;
    }
    public async Task<string> GetRenewedRefreshTokenString(Guid userId, CancellationToken cancellationToken = default)
    {
        await DeleteUserRefreshTokens(userId, cancellationToken);
        var refreshTokenString = RefreshTokenGenerator.GenerateRefreshToken();
        await AddUserRefreshTokens(userId, refreshTokenString, cancellationToken);
        return refreshTokenString;
    }

    private async Task DeleteUserRefreshTokens(Guid userId, CancellationToken cancellationToken)
    {
        await dbContext.UserRefreshTokens.Where(x => x.UserId == userId).ExecuteDeleteAsync(cancellationToken);
    }
}