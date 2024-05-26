using Domain.DataTypes;

namespace Application.Models;

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