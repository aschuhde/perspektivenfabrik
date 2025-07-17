using System.Collections.Concurrent;
using System.Threading.Channels;
using Common;
using Domain.Enums;
using Infrastructure.Data;
using Infrastructure.Data.DbEntities;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Services;

public class NotificationStorageService(IServiceProvider serviceProvider)
{
  private readonly Channel<NotificationObject> _channel = Channel.CreateUnbounded<NotificationObject>();
  
  private readonly ConcurrentBag<NotificationObject> _bag = new();
  private bool _isLoadedFromDatabase;
  public async Task<NotificationObject[]> GetPendingNotifications(CancellationToken ct)
  {
    if (!_isLoadedFromDatabase)
    {
      _isLoadedFromDatabase = true;
      using var scope = serviceProvider.CreateScope();
      var dbContext = ThrowIf.Null(scope.ServiceProvider.GetService<ApplicationDbContext>());
      var notifications = await dbContext.Tasks
        .Where(x => x.TaskType == TaskType.Notification && x.TaskStatus == TaskCompletionStatus.Pending).AsNoTracking()
        .ToArrayAsync(ct);
      foreach (var entry in notifications)
      {
        _bag.Add(FromDbTask(entry));
      }
    }
    
    return _bag.ToArray();
  }

  private void ClearCompletedNotifications()
  {
    var stillPendingNotifications = _bag.Where(x => x.TaskStatus == TaskCompletionStatus.Pending).ToArray();
    _bag.Clear();
    foreach (var entry in stillPendingNotifications)
    {
      _bag.Add(entry);
    }
  }
  
  private NotificationObject FromDbTask(DbTask dbTask)
  {
    return new NotificationObject()
    {
      TaskStatus = dbTask.TaskStatus,
      Id = dbTask.EntityId,
      Type = Enum.TryParse<NotificationObjectType>(dbTask.TaskName, out var r) ? r : NotificationObjectType.Unknown,
    }.WithJsonData(dbTask.TaskData);
  }
  private DbTask ToDbTask(NotificationObject notificationObject)
  {
    return new DbTask()
    {
      TaskStatus = notificationObject.TaskStatus,
      TaskData = notificationObject.ToJson(),
      TaskName = notificationObject.Type.ToString(),
      TaskType = TaskType.Notification,
      EntityId = notificationObject.Id
    };
  }
  
  public void StoreNotification(NotificationObject notificationObject)
  {
    if (!_channel.Writer.TryWrite(notificationObject))
    {
      throw new Exception("Channel cannot take notification object. This exception should never occur.");
    }
  }

  public async Task HandleIncomingNotification(CancellationToken ct)
  {
    var notificationObject = await _channel.Reader.ReadAsync(ct);
    _bag.Add(notificationObject);
    using var scope = serviceProvider.CreateScope();
    var dbContext = ThrowIf.Null(scope.ServiceProvider.GetService<ApplicationDbContext>());
    dbContext.Tasks.Add(ToDbTask(notificationObject));
    await dbContext.SaveChangesAsync(ct);
  }

  public async Task CompletedNotification(Guid[] notificationIds, CancellationToken ct)
  {
    if (notificationIds.Length == 0)
    {
      return;
    }
    using var scope = serviceProvider.CreateScope();
    var dbContext = ThrowIf.Null(scope.ServiceProvider.GetService<ApplicationDbContext>());
    await dbContext.Tasks.Where(x => notificationIds.Contains(x.EntityId)).ExecuteUpdateAsync(x => x.SetProperty(y => y.TaskStatus, TaskCompletionStatus.Completed), ct);
    ClearCompletedNotifications();
  }
  
  public async Task FailedNotification(Guid[] notificationIds, CancellationToken ct)
  {
    if (notificationIds.Length == 0)
    {
      return;
    }
    using var scope = serviceProvider.CreateScope();
    var dbContext = ThrowIf.Null(scope.ServiceProvider.GetService<ApplicationDbContext>());
    await dbContext.Tasks.Where(x => notificationIds.Contains(x.EntityId)).ExecuteUpdateAsync(x => x.SetProperty(y => y.TaskStatus, TaskCompletionStatus.Failed), ct);
    ClearCompletedNotifications();
  }
}
