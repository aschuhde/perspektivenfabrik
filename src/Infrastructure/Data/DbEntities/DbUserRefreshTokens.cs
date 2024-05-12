using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.DbEntities;

[Table("UserRefreshTokens")]
public sealed class DbUserRefreshTokens : DbEntity
{
    [ForeignKey(nameof(DbUser))]
    public required Guid UserId { get; init; }
    
    [MaxLength(Constants.StringLengths.Medium)]
    public required string RefreshToken { get; init; }
    
    public required DateTimeOffset AbsoluteExpirationUtc { get; init; }
}