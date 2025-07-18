using Domain.Entities;

namespace Application.Services;

public interface ICommonDataService
{
    public Task<int> UpdateTags(ImportValueDto[] importValueDtos, CancellationToken ct);
    public Task<int> UpdateMaterials(ImportValueDto[] importValueDtos, CancellationToken ct);
    public Task<int> UpdateSkills(ImportValueDto[] importValueDtos, CancellationToken ct);
    public Task<TagDto[]> GetTags(CancellationToken ct);
    public Task<MaterialDto[]> GetMaterials(CancellationToken ct);
    public Task<SkillDto[]> GetSkills(CancellationToken ct);
}