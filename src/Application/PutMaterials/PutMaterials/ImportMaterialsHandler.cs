using Application.Common;
using Application.Services;
using Domain.Entities;

namespace Application.PutMaterials.PutMaterials;

public sealed class PutMaterialsHandler(IServiceProvider serviceProvider, ICommonDataService commonDataService) : BaseHandler<PutMaterialsRequest, PutMaterialsResponse>(serviceProvider)
{
    public override async Task<PutMaterialsResponse> ExecuteAsync(PutMaterialsRequest command, CancellationToken ct)
    {
        return new PutMaterialsResponse()
        {
            ChangesCount = await commonDataService.UpdateMaterials(command.Materials.Select(x => new ImportValueDto()
            {
                GermanName = x.GermanName,
                ItalianName = x.ItalianName,
                EntityId = x.EntityId,
                ToDelete = x.ToDelete
            }).ToArray(), ct)
        };
    }
}
