using Domain.DataTypes;

namespace Application.Models.ApiModels;

public sealed class ApiDescriptionType : ApiBaseEntityWithId
{
    public required string Name { get; init; }
    public required FormattedTitle DescriptionTitle { get; init; } 
}
