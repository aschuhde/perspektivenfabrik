using Domain.Enums;

namespace Application.Models;

public sealed class ApiProjectConnection : ApiBaseEntityWithId
{
    public required ApiProject Project { get; init; }
    public required ProjectConnectionType Type { get; init; }
}