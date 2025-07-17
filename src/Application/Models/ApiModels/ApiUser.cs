using System.Text.Json.Serialization;

namespace Application.Models.ApiModels;

public sealed class ApiUser : ApiPerson
{
    [JsonIgnore]
    public required string PasswordHash { get; init; }
    
    [JsonIgnore]
    public required bool Active { get; init; }
    
    [JsonIgnore]
    public required bool EmailConfirmed { get; init; }
    
    [JsonIgnore]
    public required string PreferredLanguageCode { get; init; }
}
