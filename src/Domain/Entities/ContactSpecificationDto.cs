using Domain.DataTypes;

namespace Domain.Entities;

public class ContactSpecificationDto : BaseEntityWithIdDto
{
    public virtual void ApplyTranslations(FieldTranslationDto[] fieldTranslations)
    {
        
    }
}

public sealed class ContactSpecificationDtoPersonalName : ContactSpecificationDto
{
    public required string PersonalName { get; init; }
    public TranslationValue[] PersonalNameTranslations { get; set; } = [];
    
    public override void ApplyTranslations(FieldTranslationDto[] fieldTranslations)
    {
        PersonalNameTranslations = fieldTranslations.Where(x => x.CorrelatedEntityId == x.EntityId && x.PropertyPath == nameof(PersonalName)).Select(x => x.ToTranslationValue()).ToArray();
    }
}
public sealed class ContactSpecificationDtoOrganisationName : ContactSpecificationDto
{
    public required string OrganisationName { get; init; }
    public TranslationValue[] OrganisationNameTranslations { get; set; } = [];
    
    public override void ApplyTranslations(FieldTranslationDto[] fieldTranslations)
    {
        OrganisationNameTranslations = fieldTranslations.Where(x => x.CorrelatedEntityId == x.EntityId && x.PropertyPath == nameof(OrganisationName)).Select(x => x.ToTranslationValue()).ToArray();
    }
}
public sealed class ContactSpecificationDtoPhoneNumber : ContactSpecificationDto
{
    public required PhoneNumber PhoneNumber { get; init; }
    
    public override void ApplyTranslations(FieldTranslationDto[] fieldTranslations)
    {
        PhoneNumber.PhoneNumberTextTranslations = fieldTranslations.Where(x => x.CorrelatedEntityId == x.EntityId && x.PropertyPath == nameof(PhoneNumber)).Select(x => x.ToTranslationValue()).ToArray();
    }
}

public sealed class ContactSpecificationDtoMailAddress : ContactSpecificationDto
{
    public required MailAddress MailAddress { get; init; }
    
    public override void ApplyTranslations(FieldTranslationDto[] fieldTranslations)
    {
        MailAddress.MailTranslations = fieldTranslations.Where(x => x.CorrelatedEntityId == x.EntityId && x.PropertyPath == nameof(MailAddress)).Select(x => x.ToTranslationValue()).ToArray();
    }
}

public sealed class ContactSpecificationDtoPostalAddress : ContactSpecificationDto
{
    public required PostalAddress PostalAddress { get; init; }
    
    public override void ApplyTranslations(FieldTranslationDto[] fieldTranslations)
    {
        var translations = fieldTranslations.Where(x => x.CorrelatedEntityId == x.EntityId).ToArray();
        PostalAddress.AddressDisplayNameTranslations = translations.Where(x => x.PropertyPath == nameof(PostalAddress.AddressDisplayName)).Select(x => x.ToTranslationValue()).ToArray();
        PostalAddress.AddressTextTranslations = translations.Where(x => x.PropertyPath == nameof(PostalAddress.AddressText)).Select(x => x.ToTranslationValue()).ToArray();
    }
}
public sealed class ContactSpecificationDtoBankAccount : ContactSpecificationDto
{
  public required BankAccount BankAccount { get; init; }
  
  public override void ApplyTranslations(FieldTranslationDto[] fieldTranslations)
  {
      var translations = fieldTranslations.Where(x => x.CorrelatedEntityId == x.EntityId).ToArray();
      BankAccount.AccountNameTranslations = translations.Where(x => x.PropertyPath == nameof(BankAccount.AccountName)).Select(x => x.ToTranslationValue()).ToArray();
      BankAccount.ReferenceTranslations = translations.Where(x => x.PropertyPath == nameof(BankAccount.Reference)).Select(x => x.ToTranslationValue()).ToArray();
  }
}
public sealed class ContactSpecificationDtoWebsite : ContactSpecificationDto
{
  public required Url Website { get; init; }
  public override void ApplyTranslations(FieldTranslationDto[] fieldTranslations)
  {
      Website.UrlTranslations = fieldTranslations.Where(x => x.CorrelatedEntityId == x.EntityId && x.PropertyPath == nameof(Website)).Select(x => x.ToTranslationValue()).ToArray();
  }
}
public sealed class ContactSpecificationDtoPaypal : ContactSpecificationDto
{
  public required MailAddress PaypalAddress { get; init; }
  public required Url PaypalMeAddress { get; init; }
  
  public override void ApplyTranslations(FieldTranslationDto[] fieldTranslations)
  {
      var translations = fieldTranslations.Where(x => x.CorrelatedEntityId == x.EntityId).ToArray();
      PaypalAddress.MailTranslations = translations.Where(x => x.PropertyPath == nameof(PaypalAddress)).Select(x => x.ToTranslationValue()).ToArray();
      PaypalMeAddress.UrlTranslations = translations.Where(x => x.PropertyPath == nameof(PaypalMeAddress)).Select(x => x.ToTranslationValue()).ToArray();
  }
}
