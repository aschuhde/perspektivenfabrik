using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure.Data.DbDataTypes;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DbEntities;

[Table("TimeSpecifications")]
public class DbTimeSpecification : DbEntityWithId
{
  
}

public sealed class DbTimeSpecificationPeriod : DbTimeSpecification
{
    public DbTimeSpecificationPeriodStartConnection? Start { get; set; }
    public DbTimeSpecificationPeriodEndConnection? End { get; set; }

    public DbTimeSpecificationPeriod WithoutRelatedEntites()
    {
      return new DbTimeSpecificationPeriod() { EntityId = this.EntityId };
    }

    public override void UpdateToTarget(DbEntityWithId target)
    {
      if(target is not DbTimeSpecificationPeriod period) return;
      
      if ( this.Start?.MomentId != period.Start?.MomentId)
      {
        this.Start = period.Start == null ? null : new DbTimeSpecificationPeriodStartConnection()
        {
          MomentId = period.Start.MomentId, 
        };
      }
      if ( this.End?.MomentId != period.End?.MomentId)
      {
        this.End = period.End == null ? null : new DbTimeSpecificationPeriodEndConnection()
        {
          MomentId = period.End.MomentId, 
        };
      }
    }
}

[Owned]
public sealed class DbTimeSpecificationPeriodStartConnection
{
    public DbTimeSpecificationMoment? Moment { get; set; }
    [ForeignKey(nameof(Moment))]
    public Guid MomentId { get; set; }
    
    public DbTimeSpecificationPeriodStartConnection WithoutRelatedEntites()
    {
      return new DbTimeSpecificationPeriodStartConnection() { MomentId = this.MomentId };
    }
}

[Owned]
public sealed class DbTimeSpecificationPeriodEndConnection
{
    public DbTimeSpecificationMoment? Moment { get; set; }
    [ForeignKey(nameof(Moment))]
    public Guid MomentId { get; set; }

    public DbTimeSpecificationPeriodEndConnection WithoutRelatedEntites()
    {
      return new DbTimeSpecificationPeriodEndConnection() { MomentId = this.MomentId };
    }
}

public class DbTimeSpecificationMoment : DbTimeSpecification
{
    
}

public sealed class DbTimeSpecificationDate : DbTimeSpecificationMoment
{
    public required DateOnly Date { get; set; }

    public override void UpdateToTarget(DbEntityWithId target)
    {
      if(target is not DbTimeSpecificationDate date) return;
      if (this.Date != date.Date)
      {
        this.Date = date.Date;
      }
      base.UpdateToTarget(target);
    }
}

public sealed class DbTimeSpecificationDateTime : DbTimeSpecificationMoment
{
    public required DateTimeOffset Date { get; set; }
    public override void UpdateToTarget(DbEntityWithId target)
    {
      if(target is not DbTimeSpecificationDateTime date) return;
      if (this.Date != date.Date)
      {
        this.Date = date.Date;
      }
      base.UpdateToTarget(target);
    }
}

public sealed class DbTimeSpecificationMonth : DbTimeSpecificationMoment
{
    public required DbMonth Month { get; init; }
    
    public override void UpdateToTarget(DbEntityWithId target)
    {
      if(target is not DbTimeSpecificationMonth date) return;
      this.Month.Update(date.Month);
      base.UpdateToTarget(target);
    }
}

[Table("TimeSpecificationProjectConnections")]
public sealed class DbTimeSpecificationProjectConnection : DbEntityWithId
{
    [ForeignKey(nameof(Project))]
    public required Guid ProjectId { get; init; }
    public DbProject? Project { get; init; }
    [ForeignKey(nameof(TimeSpecification))]
    public required Guid TimeSpecificationId { get; init; }
    public DbTimeSpecification? TimeSpecification { get; init; }
}

[Table("TimeSpecificationRequirementConnections")]
public sealed class DbTimeSpecificationRequirementConnection : DbEntityWithId
{
    [ForeignKey(nameof(RequirementSpecification))]
    public required Guid RequirementSpecificationId { get; init; }
    public DbRequirementSpecification? RequirementSpecification { get; init; }
    [ForeignKey(nameof(TimeSpecification))]
    public required Guid TimeSpecificationId { get; init; }
    public DbTimeSpecification? TimeSpecification { get; init; }
}
