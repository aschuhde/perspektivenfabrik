namespace Infrastructure.Data.DbEntities;

public class DbPerson : DbAccessControlledEntity
{
    public required string Firstname { get; init; }
    public required string Lastname { get; init; }
    public required string Email { get; init; }
}
