namespace Domain.Entities;

public sealed class UserDto : PersonDto
{
    public required string PasswordHash { get; init; }
    
    public required bool Active { get; init; }
}
