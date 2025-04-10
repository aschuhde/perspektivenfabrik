using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.DbEntities;

[Table("UserRefreshTokens")]
public sealed class DbUserRefreshTokens : DbEntity
{
    [ForeignKey(nameof(DbUser))]
    public required Guid UserId { get; init; }
    
    [MaxLength(Constants.StringLengths.Medium)]
    public required string RefreshToken { get; set; }
    
    public required DateTimeOffset AbsoluteExpirationUtc { get; set; }
    public required bool Active { get; set; }

    public override void UpdateToTarget(DbEntityWithId target)
    {
      if (target is not DbUserRefreshTokens userRefreshToken) return;
      if (this.RefreshToken != userRefreshToken.RefreshToken)
      {
        this.RefreshToken = userRefreshToken.RefreshToken;
      }

      if (this.AbsoluteExpirationUtc != userRefreshToken.AbsoluteExpirationUtc)
      {
        this.AbsoluteExpirationUtc = userRefreshToken.AbsoluteExpirationUtc;
      }

      if (this.Active != userRefreshToken.Active)
      {
        this.Active = userRefreshToken.Active;
      }
      base.UpdateToTarget(target);
    }
}
