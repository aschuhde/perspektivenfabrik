using Application.Configuration;
using Application.Services;
using Common;
using Domain.Enums;
using Infrastructure.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Services;

public class NotificationSenderService(NotificationStorageService notificationStorageService, IUserDataService userDataService, IProjectService projectService, ILogger<NotificationSenderService> logger, MailService mailService, IConfiguration configuration)
{
  public async Task SendPendingNotifications(CancellationToken contextCancellationToken)
  {
      var pendingNotifications = await notificationStorageService.GetPendingNotifications(contextCancellationToken);
      var failedNotificationIds = new List<Guid>();
      var completedNotificationIds = new List<Guid>();
      foreach (var notification in pendingNotifications)
      {
          if (notification.TaskStatus != TaskCompletionStatus.Pending)
          {
              continue;
          }
          
          try
          {
              notification.TaskStatus = TaskCompletionStatus.Running;
              if (!await SendNotification(notification, contextCancellationToken))
              {
                  throw new Exception("Notification could not be sent");
              }
              notification.TaskStatus = TaskCompletionStatus.Completed;
              completedNotificationIds.Add(notification.Id);
              
          }catch(Exception e)
          {
              notification.TaskStatus = TaskCompletionStatus.Failed;
              failedNotificationIds.Add(notification.Id);
              logger.LogError(e, "Error occured when trying to send notification with id {id} and type {type} \n {exception}", notification.Id, notification.Type, e.ToString());
          }
      }
      await notificationStorageService.CompletedNotification(completedNotificationIds.ToArray(), contextCancellationToken);
      await notificationStorageService.FailedNotification(failedNotificationIds.ToArray(), contextCancellationToken);
  }

  private async Task<bool> SendProjectNotification(NotificationObject notificationObject, CancellationToken ct)
  {
      var projectMetadata = ThrowIf.Null(await projectService.GetProjectMetadataById(ThrowIf.Null(notificationObject.RelatedEntityId)!.Value, ct));
      switch (notificationObject.Type)
      {
          case NotificationObjectType.ProjectUpdated:
              return await SendNotificationInner($"Project {projectMetadata.Title} updated", $"The project with title {projectMetadata.Title} ({projectMetadata.EntityId}) was updated by {notificationObject.UserName} ({notificationObject.UserId}).", ct);
          case NotificationObjectType.ProjectCreated:
              return await SendNotificationInner($"New project created: {projectMetadata.Title}", $"A new project with title {projectMetadata.Title} ({projectMetadata.EntityId}) was created by {notificationObject.UserName} ({notificationObject.UserId}).", ct);
          case NotificationObjectType.ProjectApproved:
              return await SendNotificationInner($"Project approved: {projectMetadata.Title}", $"The project with title {projectMetadata.Title} ({projectMetadata.EntityId}) was approved by {notificationObject.UserName} ({notificationObject.UserId}).", ct);
          case NotificationObjectType.ProjectApprovalWithdrawn:
              return await SendNotificationInner($"Project approval withdrawn: {projectMetadata.Title}", $"The approval of the project with title {projectMetadata.Title} ({projectMetadata.EntityId}) was withdrawn by {notificationObject.UserName} ({notificationObject.UserId}). {notificationObject.Message}", ct);
          case NotificationObjectType.ProjectRejected:
              return await SendNotificationInner($"Project rejected: {projectMetadata.Title}", $"The project with title {projectMetadata.Title} ({projectMetadata.EntityId}) was rejected by {notificationObject.UserName} ({notificationObject.UserId}). {notificationObject.Message}", ct);
          case NotificationObjectType.ProjectReported:
              return await SendNotificationInner($"Project reported: {projectMetadata.Title}", $"The project with title {projectMetadata.Title} ({projectMetadata.EntityId}) was reported by {notificationObject.UserName} ({notificationObject.UserId}). {notificationObject.Message}", ct);
          case NotificationObjectType.ProjectDeleted:
              return await SendNotificationInner($"Project deleted: {projectMetadata.Title}", $"The project with title {projectMetadata.Title} ({projectMetadata.EntityId}) was deleted by {notificationObject.UserName} ({notificationObject.UserId}). {notificationObject.Message}", ct);
      }
      return false;
  }
  
  private async Task<bool> SendErrorNotification(NotificationObject notificationObject, CancellationToken ct)
  {
      return await SendNotificationInner("An error occured",
          $"An error occured on request {notificationObject.RequestMethod} {notificationObject.RequestUrl} for user {notificationObject.UserName} ({notificationObject.UserId}): {notificationObject.Message}",
          ct);
  }

  private async Task<bool> SendNotificationInner(string subject, string message, CancellationToken ct)
  {
      var options = configuration.GetNotificationOptions();
      await mailService.SendMail(new MailObject()
      {
          Message = message,
          IsHtmlBody = false,
          Subject = subject,
          To = [new MailObjectAddress()
          {
              Email = options.ReceiverAddress,
              Name = options.ReceiverName
          }],
      }, ct);
      return true;
  }
  
  private async Task<bool> SendUserNotification(NotificationObject notificationObject, CancellationToken ct)
  {
      var user = ThrowIf.Null(await userDataService.GetActiveUserById(ThrowIf.Null(notificationObject.UserId)!.Value, ct));
      switch (notificationObject.Type)
      {
        case NotificationObjectType.UserRegistered:
            return await SendNotificationInner($"User {user.FirstnameLastname} registered",
                $"A new user with id {notificationObject.UserId} registered: {user.FirstnameLastname} - {user.Email}!", ct);
        case NotificationObjectType.OtpConfirmed:
            return await SendNotificationInner($"User {user.FirstnameLastname} confirmed email",
                $"The user with id {notificationObject.UserId} confirmed his email: {user.FirstnameLastname} - {user.Email}!", ct);
        default:
            await SendErrorNotification(notificationObject, ct);
            return false;
      }
  }

  
  private async Task<bool> SendNotification(NotificationObject notificationObject, CancellationToken ct)
  {
      return notificationObject.Type switch
      {
          NotificationObjectType.ProjectUpdated or NotificationObjectType.ProjectCreated
              or NotificationObjectType.ProjectApproved or NotificationObjectType.ProjectApprovalWithdrawn
              or NotificationObjectType.ProjectRejected or NotificationObjectType.ProjectReported
              or NotificationObjectType.ProjectDeleted => await SendProjectNotification(notificationObject, ct),
          NotificationObjectType.ErrorOccured => await SendErrorNotification(notificationObject, ct),
          NotificationObjectType.UserRegistered => await SendUserNotification(notificationObject, ct),
          NotificationObjectType.OtpConfirmed => await SendUserNotification(notificationObject, ct),
          NotificationObjectType.Unknown => await SendErrorNotification(notificationObject, ct),
          _ => throw new ArgumentOutOfRangeException()
      };
  }
}
