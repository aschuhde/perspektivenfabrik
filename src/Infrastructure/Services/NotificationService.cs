using Application.Services;
using Domain.Entities;

namespace Infrastructure.Services;

public class NotificationService : INotificationService
{
  public void ProjectUpdated(ProjectDto project, Guid userId, string userName)
  {
    throw new NotImplementedException();
  }

  public void ProjectCreated(ProjectDto project, Guid userId, string userName)
  {
    throw new NotImplementedException();
  }

  public void ProjectApproved(Guid projectId, string? reason, Guid userId, string userName)
  {
    throw new NotImplementedException();
  }

  public void ProjectApprovalWithdrawn(Guid projectId, string? reason, Guid userId, string userName)
  {
    throw new NotImplementedException();
  }

  public void ProjectRejected(Guid projectId, string? reason, Guid userId, string userName)
  {
    throw new NotImplementedException();
  }

  public void ProjectReported(Guid projectId, string? reason, Guid userId, string userName)
  {
    throw new NotImplementedException();
  }

  public void ProjectDeleted(Guid projectId, Guid userId, string userName)
  {
    throw new NotImplementedException();
  }

  public void ErrorOccured(Guid errorId, string exception, string requestMethod, string requestUrl, Guid? userIdIfExist)
  {
    throw new NotImplementedException();
  }

  public void UserRegistered(Guid userId)
  {
    throw new NotImplementedException();
  }

  public void OtpConfirmed(Guid userId)
  {
    throw new NotImplementedException();
  }
}
