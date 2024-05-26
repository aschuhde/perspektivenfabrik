using Domain.DataTypes;
using Domain.Enums;

namespace Application.Models;

public sealed class ApiGraphicsSpecification : ApiBaseEntity
{
    public required GraphicsType Type { get; init; }
    public required GraphicsContent Content { get; init; }
}