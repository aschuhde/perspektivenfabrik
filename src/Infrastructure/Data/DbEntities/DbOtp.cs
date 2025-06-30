using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Infrastructure.Data.DbEntities;

[Table("Otp")]
public class DbOtp : DbEntityWithId
{
    [ForeignKey(nameof(DbUser))]
    public required Guid UserId { get; init; }
    
    [MaxLength(Constants.StringLengths.Small)]
    public required string Otp { get; set; }
    
    public required DateTimeOffset AbsoluteExpirationUtc { get; set; }
    
    public required DateTimeOffset RequestedOnUtc { get; set; }
    
    public required OtpStatus Status { get; set; }
}