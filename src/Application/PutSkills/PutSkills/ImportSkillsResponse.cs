using Application.Common.Response;

namespace Application.PutSkills.PutSkills;

public sealed class PutSkillsResponse : JsonResponse
{
    public int ChangesCount { get; set; }
}

