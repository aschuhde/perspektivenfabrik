using Application.Common.Response;
using Application.Models.ApiModels;

namespace Application.GetAutocompleteEntries.GetAutocompleteEntries;

public class GetAutocompleteEntriesResponse : JsonResponse
{
    public required ApiTag[] Tags { get; init; }
    public required ApiSkill[] Skills { get; init; }
    public required ApiMaterial[] Materials { get; init; }
}

