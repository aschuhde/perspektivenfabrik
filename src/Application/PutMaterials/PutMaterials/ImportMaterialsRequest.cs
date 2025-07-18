using Application.Common;
using Application.Models.ApiModels;

namespace Application.PutMaterials.PutMaterials;

public sealed class PutMaterialsRequest : BaseRequest<PutMaterialsResponse>
{
    public ApiImportValue[] Materials { get; set; } = [];
}

