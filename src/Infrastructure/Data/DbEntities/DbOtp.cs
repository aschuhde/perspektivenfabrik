using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Infrastructure.Data.DbEntities;

[Table("Otp")]
public class DbOtp : DbEntityWithId
{
    [ForeignKey(nameof(DbUser))]
    public required Guid UserId { get; set; }
    
    [MaxLength(Constants.StringLengths.Small)]
    public required string Otp { get; set; }
    
    public required DateTimeOffset AbsoluteExpirationUtc { get; set; }
    
    public required DateTimeOffset RequestedOnUtc { get; set; }
    
    public required OtpStatus Status { get; set; }
    
    public override void UpdateToTarget(DbEntityWithId target)
    {
      if(target is not DbOtp otp) return;
      if (this.UserId != otp.UserId)
      {
        this.UserId = otp.UserId;
      }
      if (this.Otp != otp.Otp)
      {
        this.Otp = otp.Otp;
      }
      if (this.AbsoluteExpirationUtc != otp.AbsoluteExpirationUtc)
      {
        this.AbsoluteExpirationUtc = otp.AbsoluteExpirationUtc;
      }
      if (this.RequestedOnUtc != otp.RequestedOnUtc)
      {
        this.RequestedOnUtc = otp.RequestedOnUtc;
      }
      if (this.Status != otp.Status)
      {
        this.Status = otp.Status;
      }
      
      base.UpdateToTarget(target);
    }
}
