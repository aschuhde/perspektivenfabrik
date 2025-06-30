using Application.Configuration;
using Application.Services;
using Application.Tools;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Data;
using Infrastructure.Data.DbEntities;
using Infrastructure.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Services;

public sealed class OtpService(IConfiguration configuration, ApplicationDbContext dbContext, ILogger<OtpService> logger) : IOtpService
{
    public async Task<OtpDto[]> GetOpenOtps(Guid userId, CancellationToken ct)
    {
        return (await dbContext.Otps.Where(x => x.UserId == userId && 
                                                (x.Status == OtpStatus.Pending || x.Status == OtpStatus.Replaced)).ToArrayAsync(ct)).Select(x => x.ToOtpDto()).ToArray();
    }

    public async Task CreateOtp(Guid userId, CancellationToken ct)
    {
        await dbContext.Otps.Where(x => x.UserId == userId && x.Status == OtpStatus.Pending).ExecuteUpdateAsync(x => x.SetProperty(y => y.Status, OtpStatus.Replaced), ct);

        var otp = new DbOtp()
        {
            Status = OtpStatus.Pending,
            RequestedOnUtc = DateTimeOffset.UtcNow,
            UserId = userId,
            Otp = OtpGenerator.GenerateOtp(),
            AbsoluteExpirationUtc = DateTimeOffset.UtcNow.AddSeconds(configuration.GetOtpOptions().ExpirationInSeconds)
        };
        dbContext.Otps.Add(otp);
        await dbContext.SaveChangesAsync(ct);
    }

    public async Task ConfirmOtp(Guid userId, Guid[] entityIds, CancellationToken ct)
    {
        if (entityIds.Length == 0)
        {
            throw new ArgumentException("No entity ids are provided");
        }
        
        await dbContext.Users.Where(x => x.EntityId == userId).ExecuteUpdateAsync(x => x.SetProperty(y => y.EmailConfirmed, true), ct);
        
        var updated = await dbContext.Otps.Where(x => x.UserId == userId && x.Status == OtpStatus.Pending && entityIds.Contains(x.EntityId)).ExecuteUpdateAsync(x => x.SetProperty(y => y.Status, OtpStatus.Completed), ct);
        await dbContext.Otps.Where(x => x.UserId == userId && x.Status == OtpStatus.Pending).ExecuteUpdateAsync(x => x.SetProperty(y => y.Status, OtpStatus.Replaced), ct);

        if (updated == 0)
        {
            logger.LogWarning("No Otp was set to confirmed with userId {userId} and entityIds {entityIds}", userId, entityIds);
        }
    }
}