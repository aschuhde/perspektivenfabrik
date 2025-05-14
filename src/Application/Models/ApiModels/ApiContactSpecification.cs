using System.Text.Json.Serialization;
using Domain.DataTypes;

namespace Application.Models.ApiModels;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ApiContactSpecificationTypes
{
    Base, PhoneNumber, MailAddress, PostalAddress, BankAccount, Website, Paypal, PersonalName, OrganisationName
}

[JsonPolymorphic(TypeDiscriminatorPropertyName = "classType")]
[JsonDerivedType(typeof(ApiContactSpecification), typeDiscriminator: nameof(ApiContactSpecificationTypes.Base))]
[JsonDerivedType(typeof(ApiContactSpecificationPersonalName), typeDiscriminator: nameof(ApiContactSpecificationTypes.PersonalName))]
[JsonDerivedType(typeof(ApiContactSpecificationOrganisationName), typeDiscriminator: nameof(ApiContactSpecificationTypes.OrganisationName))]
[JsonDerivedType(typeof(ApiContactSpecificationPhoneNumber), typeDiscriminator: nameof(ApiContactSpecificationTypes.PhoneNumber))]
[JsonDerivedType(typeof(ApiContactSpecificationMailAddress), typeDiscriminator: nameof(ApiContactSpecificationTypes.MailAddress))]
[JsonDerivedType(typeof(ApiContactSpecificationPostalAddress), typeDiscriminator: nameof(ApiContactSpecificationTypes.PostalAddress))]
[JsonDerivedType(typeof(ApiContactSpecificationBankAccount), typeDiscriminator: nameof(ApiContactSpecificationTypes.BankAccount))]
[JsonDerivedType(typeof(ApiContactSpecificationWebsite), typeDiscriminator: nameof(ApiContactSpecificationTypes.Website))]
[JsonDerivedType(typeof(ApiContactSpecificationPaypal), typeDiscriminator: nameof(ApiContactSpecificationTypes.Paypal))]
public class ApiContactSpecification : ApiBaseEntityWithId
{
    
}

public sealed class ApiContactSpecificationPersonalName : ApiContactSpecification
{
    public required string PersonalName { get; init; }
    public TranslationValue[] PersonalNameTranslations { get; set; } = [];
}

public sealed class ApiContactSpecificationOrganisationName : ApiContactSpecification
{
    public required string OrganisationName { get; init; }
    public TranslationValue[] OrganisationNameTranslations { get; set; } = [];
}

public sealed class ApiContactSpecificationPhoneNumber : ApiContactSpecification
{
    public required PhoneNumber PhoneNumber { get; init; }
}

public sealed class ApiContactSpecificationMailAddress : ApiContactSpecification
{
    public required MailAddress MailAddress { get; init; }
}

public sealed class ApiContactSpecificationPostalAddress : ApiContactSpecification
{
    public required PostalAddress PostalAddress { get; init; }
}

public sealed class ApiContactSpecificationBankAccount : ApiContactSpecification
{
  public required BankAccount BankAccount { get; init; }
}
public sealed class ApiContactSpecificationWebsite : ApiContactSpecification
{
  public required Url Website { get; init; }
}
public sealed class ApiContactSpecificationPaypal : ApiContactSpecification
{
  public required MailAddress PaypalAddress { get; init; }
  public required Url PaypalMeAddress { get; init; }
}

