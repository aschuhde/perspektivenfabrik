using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure.Data.DbDataTypes;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DbEntities;

[Table("TimeSpecifications")]
public class DbTimeSpecification : DbEntity
{
    
}

public sealed class DbTimeSpecificationPeriod : DbTimeSpecification
{
    public required DbTimeSpecificationPeriodStartConnection Start { get; init; }
    public required DbTimeSpecificationPeriodEndConnection End { get; init; }
}

[Owned]
public sealed class DbTimeSpecificationPeriodStartConnection
{
    public DbTimeSpecificationMoment? Moment { get; set; }
    [ForeignKey(nameof(Moment))]
    public Guid MomentId { get; set; }
}

[Owned]
public sealed class DbTimeSpecificationPeriodEndConnection
{
    public DbTimeSpecificationMoment? Moment { get; set; }
    [ForeignKey(nameof(Moment))]
    public Guid MomentId { get; set; }
}

public class DbTimeSpecificationMoment : DbTimeSpecification
{
    
}

public sealed class DbTimeSpecificationDate : DbTimeSpecificationMoment
{
    public required DateOnly Date { get; init; }
}

public sealed class DbTimeSpecificationDateTime : DbTimeSpecificationMoment
{
    public required DateTimeOffset Date { get; init; }
}

public sealed class DbTimeSpecificationMonth : DbTimeSpecificationMoment
{
    public required DbMonth Month { get; init; }
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