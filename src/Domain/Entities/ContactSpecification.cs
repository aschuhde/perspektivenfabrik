using Domain.DataTypes;

namespace Domain.Entities;

public class ContactSpecification : BaseEntity
{
    
}

public sealed class ContactSpecificationPhoneNumber : ContactSpecification
{
    public required PhoneNumber PhoneNumber { get; init; }
}

public sealed class ContactSpecificationMailAddress : ContactSpecification
{
    public required MailAddress MailAddress { get; init; }
}

public sealed class ContactSpecificationPostalAddress : ContactSpecification
{
    public required PostalAddress PostalAddress { get; init; }
}