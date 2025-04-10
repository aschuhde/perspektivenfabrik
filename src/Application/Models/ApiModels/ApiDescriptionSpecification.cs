using Domain.DataTypes;

namespace Application.Models.ApiModels;

public sealed class ApiDescriptionSpecification : ApiBaseEntityWithId
{
    public required ApiDescriptionType Type { get; init; }
    public required FormattedContent Content { get; init; }
}