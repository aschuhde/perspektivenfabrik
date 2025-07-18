using Application.Common.Response;

namespace Application.PutMaterials.PutMaterials;

public sealed class PutMaterialsResponse : JsonResponse
{
    public int ChangesCount { get; set; }
}

