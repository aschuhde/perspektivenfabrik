using Application.Common;
using Application.Mapping;
using Application.Services;

namespace Application.GetAutocompleteEntries.GetAutocompleteEntries;

public class GetAutocompleteEntriesHandler(IServiceProvider serviceProvider, ICommonDataService commonDataService) : BaseHandler<GetAutocompleteEntriesRequest, GetAutocompleteEntriesResponse>(serviceProvider)
{
    public override async Task<GetAutocompleteEntriesResponse> ExecuteAsync(GetAutocompleteEntriesRequest command, CancellationToken ct)
    {
        return new GetAutocompleteEntriesResponse()
        {
            Tags = (await commonDataService.GetTags(ct)).Select(x => x.ToApiTag()).ToArray(),
            Materials = (await commonDataService.GetMaterials(ct)).Select(x => x.ToApiMaterial()).ToArray(),
            Skills = (await commonDataService.GetSkills(ct)).Select(x => x.ToApiSkill()).ToArray()
        };
    }
}
