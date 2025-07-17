using Domain.Entities;

namespace Application.Services;

public interface IOtpService
{
    public Task<OtpDto[]> GetOpenOtps(Guid userId, CancellationToken ct);
    public Task<OtpDto> CreateOtp(Guid userId, CancellationToken ct);
    public Task ConfirmOtp(Guid userId, Guid[] entityIds, CancellationToken ct);
}