using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure.Data.DbDataTypes;

namespace Infrastructure.Data.DbEntities;

[Table("ContactSpecifications")]
public class DbContactSpecification : DbEntityWithId
{
    
}

public sealed class DbContactSpecificationPersonalName : DbContactSpecification
{
    public required string PersonalName { get; set; }

    public override void UpdateToTarget(DbEntityWithId target)
    {
        if (target is not DbContactSpecificationPersonalName targetEntity) return;
        this.PersonalName = targetEntity.PersonalName;
    }
}

public sealed class DbContactSpecificationOrganisationName : DbContactSpecification
{
    public required string OrganisationName { get; set; }
    public override void UpdateToTarget(DbEntityWithId target)
    {
      if (target is not DbContactSpecificationOrganisationName targetEntity) return;
      this.OrganisationName = targetEntity.OrganisationName;
    }
}

public sealed class DbContactSpecificationPhoneNumber : DbContactSpecification
{
    public required DbPhoneNumber PhoneNumber { get; set; }
    public override void UpdateToTarget(DbEntityWithId target)
    {
      if (target is not DbContactSpecificationPhoneNumber targetEntity) return;
      this.PhoneNumber.Update(targetEntity.PhoneNumber);
    }
}

public sealed class DbContactSpecificationMailAddress : DbContactSpecification
{
    public required DbMailAddress MailAddress { get; set; }
    public override void UpdateToTarget(DbEntityWithId target)
    {
      if (target is not DbContactSpecificationMailAddress targetEntity) return;
      this.MailAddress.Update(targetEntity.MailAddress);
    }
    
}

public sealed class DbContactSpecificationPostalAddress : DbContactSpecification
{
    public required DbPostalAddress PostalAddress { get; set; }
    public override void UpdateToTarget(DbEntityWithId target)
    {
      if (target is not DbContactSpecificationPostalAddress targetEntity) return;
      this.PostalAddress.Update(targetEntity.PostalAddress);
    }
}

public sealed class DbContactSpecificationBankAccount : DbContactSpecification
{
  public required DbBankAccount BankAccount { get; set; }
  public override void UpdateToTarget(DbEntityWithId target)
  {
    if (target is not DbContactSpecificationBankAccount targetEntity) return;
    this.BankAccount.Update(targetEntity.BankAccount);
  }
}
public sealed class DbContactSpecificationWebsite : DbContactSpecification
{
  public required DbUrl Website { get; init; }
  public override void UpdateToTarget(DbEntityWithId target)
  {
    if (target is not DbContactSpecificationWebsite targetEntity) return;
    this.Website.Update(targetEntity.Website);
  }
}
public sealed class DbContactSpecificationPaypal : DbContactSpecification
{
  public required DbMailAddress PaypalAddress { get; init; }
  public required DbUrl PaypalMeAddress { get; init; }
  
  public override void UpdateToTarget(DbEntityWithId target)
  {
    if (target is not DbContactSpecificationPaypal targetEntity) return;
    this.PaypalAddress.Update(targetEntity.PaypalAddress);
    this.PaypalMeAddress.Update(targetEntity.PaypalMeAddress);
  }
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
