using System.Text.Json.Serialization;
using Domain.DataTypes;

namespace Application.Models.ApiModels;

[JsonDerivedType(typeof(ApiContactSpecification), typeDiscriminator: "base")]
[JsonDerivedType(typeof(ApiContactSpecificationPhoneNumber), typeDiscriminator: "withPhoneNumber")]
[JsonDerivedType(typeof(ApiContactSpecificationMailAddress), typeDiscriminator: "withMailAddress")]
[JsonDerivedType(typeof(ApiContactSpecificationPostalAddress), typeDiscriminator: "withPostalAddress")]
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