using Domain.DataTypes;
using Domain.Enums;

namespace Application.Models.ApiModels;

public sealed class ApiGraphicsSpecification : ApiBaseEntityWithId
{
    public required GraphicsType Type { get; init; }
    public required Guid ImageId { get; init; }
}
