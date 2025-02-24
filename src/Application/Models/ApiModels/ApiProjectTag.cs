namespace Application.Models.ApiModels;

public sealed class ApiProjectTag : ApiBaseEntityWithId
{
    public required string TagName { get; init; }
}