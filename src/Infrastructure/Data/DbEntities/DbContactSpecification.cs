using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure.Data.DbDataTypes;

namespace Infrastructure.Data.DbEntities;

[Table("ContactSpecifications")]
public class DbContactSpecification : DbEntity
{
    
}

public sealed class DbContactSpecificationPhoneNumber : DbContactSpecification
{
    public required DbPhoneNumber PhoneNumber { get; init; }
}

public sealed class DbContactSpecificationMailAddress : DbContactSpecification
{
    public required DbMailAddress MailAddress { get; init; }
}

public sealed class DbContactSpecificationPostalAddress : DbContactSpecification
{
    public required DbPostalAddress PostalAddress { get; init; }
}

[Table("ContactSpecificationConnections")]
public sealed class DbContactSpecificationProjectConnection : DbEntityWithId
{
    [ForeignKey(nameof(Project))]
    public required Guid ProjectId { get; init; }
    public DbProject? Project { get; init; }
    [ForeignKey(nameof(ContactSpecification))]
    public required Guid ContactSpecificationId { get; init; }
    public DbContactSpecification? ContactSpecification { get; init; }
}