using Application.Common;
using Application.Mapping;
using Application.Services;

namespace Application.GetAutocompleteEntries.GetAutocompleteEntries;

public class GetAutocompleteEntriesHandler(IServiceProvider serviceProvider, IProjectService projectService) : BaseHandler<GetAutocompleteEntriesRequest, GetAutocompleteEntriesResponse>(serviceProvider)
{
    public override async Task<GetAutocompleteEntriesResponse> ExecuteAsync(GetAutocompleteEntriesRequest command, CancellationToken ct)
    {
        return new GetAutocompleteEntriesResponse()
        {
            Tags = (await projectService.GetTags(ct)).Select(x => x.ToApiTag()).ToArray(),
            Materials = (await projectService.GetMaterials(ct)).Select(x => x.ToApiMaterial()).ToArray(),
            Skills = (await projectService.GetSkills(ct)).Select(x => x.ToApiSkill()).ToArray()
        };
    }
}
