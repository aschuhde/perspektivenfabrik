using Domain.Enums;

namespace Application.Models.ApiModels;

public sealed class ApiOrganizationReference
{
    public required Guid OrganizationEntityId { get; init; }
}

public sealed class ApiProjectReference
{
    public required Guid ProjectId { get; init; }
    public required ProjectConnectionType Type { get; init; }
}

public sealed class ApiPersonReference
{
    public required Guid PersonEntityId { get; init; }
}