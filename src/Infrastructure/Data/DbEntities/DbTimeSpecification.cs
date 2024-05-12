using System.ComponentModel.DataAnnotations.Schema;
using Domain.DataTypes;

namespace Infrastructure.Data.DbEntities;

[Table("TimeSpecifications")]
public class DbTimeSpecification : DbEntity
{
    
}

public sealed class DbTimeSpecificationPeriod : DbTimeSpecification
{
    public required DbTimeSpecificationMomentPeriodConnection Start { get; init; }
    public required DbTimeSpecificationMomentPeriodConnection End { get; init; }
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
    public required Month Month { get; init; }
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

[Table("TimeSpecificationMomentPeriodConnections")]
public sealed class DbTimeSpecificationMomentPeriodConnection : DbEntityWithId
{
    [ForeignKey(nameof(TimeSpecificationPeriod))]
    public required Guid TimeSpecificationPeriodId { get; init; }
    public required DbTimeSpecificationPeriod? TimeSpecificationPeriod { get; init; }
    [ForeignKey(nameof(TimeSpecificationMoment))]
    public required Guid TimeSpecificationMomentId { get; init; }
    public required DbTimeSpecificationMoment? TimeSpecificationMoment { get; init; }
}

[Table("TimeSpecificationRequirementConnections")]
public sealed class DbTimeSpecificationRequirementConnection : DbEntityWithId
{
    [ForeignKey(nameof(RequirementSpecification))]
    public required Guid RequirementSpecificationId { get; init; }
    public required DbRequirementSpecification? RequirementSpecification { get; init; }
    [ForeignKey(nameof(TimeSpecification))]
    public required Guid TimeSpecificationId { get; init; }
    public required DbTimeSpecification? TimeSpecification { get; init; }
}