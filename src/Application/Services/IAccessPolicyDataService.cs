using Domain.Entities;

namespace Application.Services;

public interface IAccessPolicyDataService
{
    public Task<AccessPolicy[]> GetReadPolicies(Guid userId, CancellationToken cancellationToken = default);
    public Task<AccessPolicy[]> GetWritePolicies(Guid userId, CancellationToken cancellationToken = default);
}
