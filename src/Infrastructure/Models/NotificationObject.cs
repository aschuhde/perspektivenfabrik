using Domain.Enums;

namespace Infrastructure.Models;

public class NotificationObject
{
  public required TaskCompletionStatus TaskStatus { get; set; }
}
