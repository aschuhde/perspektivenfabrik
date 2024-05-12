using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DbDataTypes;

[Owned]
public sealed class DbCoordinates
{
    public required double Lat { get; init; }
    public required double Lon { get; init; }
}