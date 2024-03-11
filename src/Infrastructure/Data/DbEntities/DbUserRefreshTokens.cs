using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.DbEntities;

[Table("DbUserRefreshTokens")]
public class DbUserRefreshTokens : DbBaseEntity
{
    [ForeignKey(nameof(DbUser))]
    public required Guid UserId { get; init; }
    
    [MaxLength(Constants.StringLengths.Medium)]
    public required string RefreshToken { get; init; }
    
    public required DateTimeOffset AbsoluteExpirationUtc { get; init; }
}