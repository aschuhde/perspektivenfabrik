using System.Text.Json;
using System.Text.Json.Serialization;
using Domain.Enums;

namespace Infrastructure.Models;

public sealed class NotificationObject : NotificationObjectBase
{
  [JsonIgnore]
  public Guid Id { get; init; } = Guid.NewGuid();
  [JsonIgnore]
  public TaskCompletionStatus TaskStatus { get; set; } = TaskCompletionStatus.Pending;
  [JsonIgnore]
  public NotificationObjectType Type { get; set; } = NotificationObjectType.Unknown;
  
  public NotificationObject WithJsonData(string dbTaskTaskData)
  {
    var baseData = JsonSerializer.Deserialize<NotificationObjectBase>(dbTaskTaskData);
    RelatedEntityId = baseData?.RelatedEntityId;
    Message = baseData?.Message;
    RequestMethod = baseData?.RequestMethod;
    RequestUrl = baseData?.RequestUrl;
    UserId = baseData?.UserId;
    UserName = baseData?.UserName;
    return this; 
  }

  public string ToJson()
  {
    return JsonSerializer.Serialize(this);
  }
}

public class NotificationObjectBase
{
  public Guid? UserId { get; set; }
  public string? UserName { get; set; }
  public Guid? RelatedEntityId { get; set; }
  public string? Message { get; set; }
  public string? RequestMethod { get; set; }
  public string? RequestUrl { get; set; }
}
