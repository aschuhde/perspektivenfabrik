﻿using Domain.DataTypes;
using Domain.Entities;

namespace Application.Services;

public interface IRefreshTokenRepositoryService
{
    Task<UserRefreshToken?> GetSavedRefreshToken(Guid userId, CancellationToken cancellationToken = default);
    
    public Task<string> GetRenewedRefreshTokenStringIfNecessary(Guid userId, CancellationToken cancellationToken = default);
    public Task<string> GetRenewedRefreshTokenString(Guid userId, CancellationToken cancellationToken = default);
}