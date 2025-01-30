using Domain.DataTypes;

namespace Application.Models.ApiModels;

public sealed class ApiMaterialSpecification : ApiBaseEntity
{
    public required string Name { get; init; }
    public required FormattedContent Title  { get; init; }
    public required FormattedContent Description { get; init; }
}