using Application.Common;
using Application.Models.ApiModels;

namespace Application.PutSkills.PutSkills;

public sealed class PutSkillsRequest : BaseRequest<PutSkillsResponse>
{
    public ApiImportValue[] Skills { get; set; } = [];
}

