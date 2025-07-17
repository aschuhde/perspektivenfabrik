using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Infrastructure.Data.DbEntities;

[Table("Tasks")]
public class DbTask: DbEntityWithId
{
  [MaxLength(Constants.StringLengths.Medium)]
  public required string TaskName { get; set; }
  
  public required TaskType TaskType { get; set; }
  
  public required TaskCompletionStatus TaskStatus { get; set; }
  
  [MaxLength(Constants.StringLengths.Largest)]
  public required string TaskData { get; set; }
  
  public override void UpdateToTarget(DbEntityWithId target)
  {
    if(target is not DbTask task) return;
    if (this.TaskName != task.TaskName)
    {
      this.TaskName = task.TaskName;
    }
    if (this.TaskType != task.TaskType)
    {
      this.TaskType = task.TaskType;
    }
    if (this.TaskData != task.TaskData)
    {
      this.TaskData = task.TaskData;
    }
    if (this.TaskStatus != task.TaskStatus)
    {
      this.TaskStatus = task.TaskStatus;
    }
      
    base.UpdateToTarget(target);
  }
}
