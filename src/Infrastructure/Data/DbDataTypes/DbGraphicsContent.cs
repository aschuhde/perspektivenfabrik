using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DbDataTypes;

[Owned]
public sealed class DbGraphicsContent
{
    public required byte[] Content { get; init; }
}