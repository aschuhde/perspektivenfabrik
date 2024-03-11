using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.DbEntities;

[Table("User")]
public class DbUser : DbPerson
{
    [MaxLength(Constants.StringLengths.Medium)]
    public required string PasswordHash { get; init; }
}
