using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure.Data.DbDataTypes;

namespace Infrastructure.Data.DbEntities;

[Table("ContactSpecifications")]
public class DbContactSpecification : DbEntityWithId
{
    
}

public sealed class DbContactSpecificationPersonalName : DbContactSpecification
{
    public required string PersonalName { get; init; }
}

public sealed class DbContactSpecificationOrganisationName : DbContactSpecification
{
    public required string OrganisationName { get; init; }
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

public sealed class DbContactSpecificationBankAccount : DbContactSpecification
{
  public required DbBankAccount BankAccount { get; init; }
}
public sealed class DbContactSpecificationWebsite : DbContactSpecification
{
  public required DbUrl Website { get; init; }
}
public sealed class DbContactSpecificationPaypal : DbContactSpecification
{
  public required DbMailAddress PaypalAddress { get; init; }
  public required DbUrl PaypalMeAddress { get; init; }
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

    public DbContactSpecificationProjectConnection WithoutRelatedEntites()
    {
      return new DbContactSpecificationProjectConnection()
      {
        ProjectId = this.ProjectId, ContactSpecificationId = this.ContactSpecificationId, EntityId = this.EntityId
      };
    }
}
