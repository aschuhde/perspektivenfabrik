using Application.Common;
using Application.Models.ApiModels;

namespace Application.PutTags.PutTags;

public sealed class PutTagsRequest : BaseRequest<PutTagsResponse>
{
    public ApiImportValue[] Tags { get; set; } = [];
}

