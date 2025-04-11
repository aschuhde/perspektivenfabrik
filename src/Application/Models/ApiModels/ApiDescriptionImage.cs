using Domain.DataTypes;

namespace Application.Models.ApiModels;

public sealed class ApiDescriptionImage : ApiBaseEntityWithId
{
    public required Guid ProjectId { get; init; }
    public required GraphicsContent Content { get; init; }
}