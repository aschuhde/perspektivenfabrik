using System.Text.Json.Serialization;
using Domain.DataTypes;

namespace Application.Models.ApiModels;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ApiContactSpecificationTypes
{
    Base, PhoneNumber, MailAddress, PostalAddress,
}

[JsonPolymorphic(TypeDiscriminatorPropertyName = "classType")]
[JsonDerivedType(typeof(ApiContactSpecification), typeDiscriminator: nameof(ApiContactSpecificationTypes.Base))]
[JsonDerivedType(typeof(ApiContactSpecificationPhoneNumber), typeDiscriminator: nameof(ApiContactSpecificationTypes.PhoneNumber))]
[JsonDerivedType(typeof(ApiContactSpecificationMailAddress), typeDiscriminator: nameof(ApiContactSpecificationTypes.MailAddress))]
[JsonDerivedType(typeof(ApiContactSpecificationPostalAddress), typeDiscriminator: nameof(ApiContactSpecificationTypes.PostalAddress))]
public class ApiContactSpecification : ApiBaseEntity
{
    
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