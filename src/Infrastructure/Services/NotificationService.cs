using Application.Services;
using Domain.Enums;
using Infrastructure.Models;

namespace Infrastructure.Services;

public class NotificationService(NotificationStorageService storageService) : INotificationService
{
  public void ProjectUpdated(Guid projectId, Guid userId, string userName)
  {
    storageService.StoreNotification(new NotificationObject()
    {
      TaskStatus = TaskCompletionStatus.Pending,
      RelatedEntityId = projectId,
      UserId = userId,
      UserName = userName,
      Type = NotificationObjectType.ProjectUpdated
    });
  }

  public void ProjectCreated(Guid projectId, Guid userId, string userName)
  {
    storageService.StoreNotification(new NotificationObject()
    {
      TaskStatus = TaskCompletionStatus.Pending,
      RelatedEntityId = projectId,
      UserId = userId,
      UserName = userName,
      Type = NotificationObjectType.ProjectCreated
    });
  }

  public void ProjectApproved(Guid projectId, string? reason, Guid userId, string userName)
  {
    storageService.StoreNotification(new NotificationObject()
    {
      TaskStatus = TaskCompletionStatus.Pending,
      RelatedEntityId = projectId,
      UserId = userId,
      UserName = userName,
      Message = reason,
      Type = NotificationObjectType.ProjectApproved
    });
  }

  public void ProjectApprovalWithdrawn(Guid projectId, string? reason, Guid userId, string userName)
  {
    storageService.StoreNotification(new NotificationObject()
    {
      TaskStatus = TaskCompletionStatus.Pending,
      RelatedEntityId = projectId,
      UserId = userId,
      UserName = userName,
      Message = reason,
      Type = NotificationObjectType.ProjectApprovalWithdrawn
    });
  }

  public void ProjectRejected(Guid projectId, string? reason, Guid userId, string userName)
  {
    storageService.StoreNotification(new NotificationObject()
    {
      TaskStatus = TaskCompletionStatus.Pending,
      RelatedEntityId = projectId,
      UserId = userId,
      UserName = userName,
      Message = reason,
      Type = NotificationObjectType.ProjectRejected
    });
  }

  public void ProjectReported(Guid projectId, string? reason, Guid userId, string userName)
  {
    storageService.StoreNotification(new NotificationObject()
    {
      TaskStatus = TaskCompletionStatus.Pending,
      RelatedEntityId = projectId,
      UserId = userId,
      UserName = userName,
      Message = reason,
      Type = NotificationObjectType.ProjectReported
    });
  }

  public void ProjectDeleted(Guid projectId, Guid userId, string userName)
  {
    storageService.StoreNotification(new NotificationObject()
    {
      TaskStatus = TaskCompletionStatus.Pending,
      RelatedEntityId = projectId,
      UserId = userId,
      UserName = userName,
      Type = NotificationObjectType.ProjectDeleted
    });
  }

  public void ErrorOccured(Guid errorId, string exception, string requestMethod, string requestUrl, Guid? userIdIfExist)
  {
    storageService.StoreNotification(new NotificationObject()
    {
      TaskStatus = TaskCompletionStatus.Pending,
      UserId = userIdIfExist,
      RelatedEntityId = errorId,
      Message = exception,
      RequestMethod = requestMethod,
      RequestUrl = requestUrl,
      Type = NotificationObjectType.ErrorOccured
    });
  }

  public void UserRegistered(Guid userId)
  {
    storageService.StoreNotification(new NotificationObject()
    {
      TaskStatus = TaskCompletionStatus.Pending,
      UserId = userId,
      Type = NotificationObjectType.UserRegistered
    });
  }

  public void OtpConfirmed(Guid userId)
  {
    storageService.StoreNotification(new NotificationObject()
    {
      TaskStatus = TaskCompletionStatus.Pending,
      UserId = userId,
      Type = NotificationObjectType.OtpConfirmed
    });
  }
}
