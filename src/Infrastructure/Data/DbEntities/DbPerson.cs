using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.DbEntities;

[Table("Persons")]
public class DbPerson : DbEntity
{
    public required string Firstname { get; init; }
    public required string Lastname { get; init; }
    public required string Email { get; init; }
}
