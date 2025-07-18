using Application.Common.Response;

namespace Application.PutTags.PutTags;

public sealed class PutTagsResponse : JsonResponse
{
    public int ChangesCount { get; set; }
}

