namespace Application.Models.ApiModels;

public sealed class ApiProjectTag : ApiBaseEntity
{
    public required string TagName { get; init; }
}