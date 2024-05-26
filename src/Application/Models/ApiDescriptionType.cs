using Domain.DataTypes;

namespace Application.Models;

public sealed class ApiDescriptionType : ApiBaseEntity
{
    public required string Name { get; init; }
    public required FormattedTitle DescriptionTitle { get; init; } 
}