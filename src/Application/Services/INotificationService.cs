using Domain.Entities;

namespace Application.Services;

public interface INotificationService
{
    public void ProjectUpdated(ProjectDto project, Guid userId, string userName);
    public void ProjectCreated(ProjectDto project, Guid userId, string userName);
    public void ProjectApproved(Guid projectId, string? reason, Guid userId, string userName);
    public void ProjectApprovalWithdrawn(Guid projectId, string? reason, Guid userId, string userName);
    public void ProjectRejected(Guid projectId, string? reason, Guid userId, string userName);
    public void ProjectReported(Guid projectId, string? reason, Guid userId, string userName);
    public void ProjectDeleted(Guid projectId, Guid userId, string userName);
    public void ErrorOccured(Guid errorId, string exception, string requestMethod, string requestUrl, Guid? userIdIfExist);
    public void UserRegistered(Guid userId);
    public void OtpConfirmed(Guid userId);
}