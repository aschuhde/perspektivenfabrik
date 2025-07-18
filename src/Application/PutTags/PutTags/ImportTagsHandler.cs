using Application.Common;
using Application.Services;
using Domain.Entities;

namespace Application.PutTags.PutTags;

public sealed class PutTagsHandler(IServiceProvider serviceProvider, ICommonDataService commonDataService) : BaseHandler<PutTagsRequest, PutTagsResponse>(serviceProvider)
{
    public override async Task<PutTagsResponse> ExecuteAsync(PutTagsRequest command, CancellationToken ct)
    {
        return new PutTagsResponse()
        {
            ChangesCount = await commonDataService.UpdateTags(command.Tags.Select(x => new ImportValueDto()
            {
                GermanName = x.GermanName,
                ItalianName = x.ItalianName,
                EntityId = x.EntityId,
                ToDelete = x.ToDelete
            }).ToArray(), ct)
        };
    }
}
