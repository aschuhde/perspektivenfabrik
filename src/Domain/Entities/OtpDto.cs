using Domain.Enums;

namespace Domain.Entities;

public class OtpDto : BaseEntityWithIdDto
{
    public required Guid UserId { get; init; }
    
    public required string Otp { get; init; }
    
    public required DateTimeOffset AbsoluteExpirationUtc { get; init; }
    
    public required DateTimeOffset RequestedOnUtc { get; init; }
    
    public required OtpStatus Status { get; init; }
}