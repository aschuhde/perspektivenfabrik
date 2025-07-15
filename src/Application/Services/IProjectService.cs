using Application.Filter;
using Application.Models.ProjectService;
using Application.Selectors;
using Application.Updaters;
using Domain.Entities;
using Domain.Enums;

namespace Application.Services;

public interface IProjectService
{
    public Task<ProjectDto[]> GetPublicProjects(ProjectFilter? projectFilter, ProjectSelector? projectSelector, CancellationToken ct);
    public Task<ProjectDto[]> GetUsersProjects(ProjectFilter? projectFilter, ProjectSelector? projectSelector, CancellationToken ct);
    public Task<ProjectDto[]> GetPendingApprovalProjects(ProjectFilter? projectFilter, ProjectSelector? projectSelector, CancellationToken ct);
    public Task<ProjectDto[]> GetAllApprovalProjects(ProjectFilter? projectFilter, ProjectSelector? projectSelector, CancellationToken ct);
    public Task<ProjectDto?> GetProjectById(Guid entityId, CancellationToken ct);
    public Task<CreateorUpdateProjectResult> CreateOrUpdateProject(ProjectDto project, EntityUpdatingContext changeContext, CancellationToken ct);
    public Task<ProjectDto?> GetProjectWithHistoryByIdAndCacheDbProject(Guid entityId, CancellationToken ct);
    public Task SoftDeleteProject(Guid entityId, CancellationToken ct);
    public Task<TagDto[]> GetTags(CancellationToken ct);
    public Task<MaterialDto[]> GetMaterials(CancellationToken ct);
    public Task<SkillDto[]> GetSkills(CancellationToken ct);
    public Task<Guid> AddProjectImage(Guid projectId, byte[] image, CancellationToken ct);
    public Task<ProjectImageDto?> GetProjectImage(Guid projectId, Guid imageId, CancellationToken ct);
    public Task<Guid?> GetOwnerId(Guid projectId, CancellationToken ct);
    public Task<Guid[]?> GetContributorIds(Guid projectId, CancellationToken ct);
    public Task<bool> ProjectExists(Guid projectId, CancellationToken ct);
    public Task<ApproveProjectResult> UpdateProjectApprovalStatus(ApprovalStatus approvalStatus, Guid commandEntityId, string displayName, string? dataReason, CancellationToken ct);
    public Task<ProjectMetadata?> GetProjectMetadataById(Guid projectId, CancellationToken ct);
}
