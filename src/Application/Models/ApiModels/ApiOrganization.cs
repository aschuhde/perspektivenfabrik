namespace Application.Models.ApiModels;

public sealed class ApiOrganization : ApiBaseEntity
{
    public required string Name { get; init; }
}