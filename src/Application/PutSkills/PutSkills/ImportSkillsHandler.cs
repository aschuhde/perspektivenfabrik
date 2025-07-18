using Application.Common;
using Application.Services;
using Domain.Entities;

namespace Application.PutSkills.PutSkills;

public sealed class PutSkillsHandler(IServiceProvider serviceProvider, ICommonDataService commonDataService) : BaseHandler<PutSkillsRequest, PutSkillsResponse>(serviceProvider)
{
    public override async Task<PutSkillsResponse> ExecuteAsync(PutSkillsRequest command, CancellationToken ct)
    {
        return new PutSkillsResponse()
        {
            ChangesCount = await commonDataService.UpdateSkills(command.Skills.Select(x => new ImportValueDto()
            {
                GermanName = x.GermanName,
                ItalianName = x.ItalianName,
                EntityId = x.EntityId,
                ToDelete = x.ToDelete
            }).ToArray(), ct)
        };
    }
}
