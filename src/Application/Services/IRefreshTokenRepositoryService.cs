using Domain.DataTypes;

namespace Application.Services;

public interface IRefreshTokenRepositoryService
{
    Task<UserRefreshToken[]> GetSavedRefreshTokens(Guid userId, CancellationToken cancellationToken = default);
    
    public Task<string> GetRenewedRefreshTokenStringIfNecessary(Guid userId, CancellationToken cancellationToken = default);
    public Task<string> GetRenewedRefreshTokenString(Guid userId, CancellationToken cancellationToken = default);
}