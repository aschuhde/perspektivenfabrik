using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.DbEntities;

[Table("Persons")]
public class DbPerson : DbEntity
{
    [MaxLength(Constants.StringLengths.Medium)]
    public required string Firstname { get; init; }
    [MaxLength(Constants.StringLengths.Medium)]
    public required string Lastname { get; init; }
    [MaxLength(Constants.StringLengths.Medium)]
    public required string Email { get; init; }
}
public sealed class DbUser : DbPerson
{
    [MaxLength(Constants.StringLengths.Medium)]
    public required string PasswordHash { get; init; }
}
