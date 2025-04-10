using Application.Models.ApiModels;
using Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Application.Mapping;


public static partial class ApiMappingExtensions
{
    // From Api
    internal static partial ContactSpecificationDto ToContactSpecificationInner(this ApiContactSpecification apiContactSpecification);
    public static partial ContactSpecificationDtoPhoneNumber ToContactSpecificationPhoneNumber(this ApiContactSpecificationPhoneNumber apiContactSpecificationPhoneNumber);
    public static partial ContactSpecificationDtoMailAddress ToContactSpecificationMailAddress(this ApiContactSpecificationMailAddress apiContactSpecificationMailAddress);
    public static partial ContactSpecificationDtoOrganisationName ToContactSpecificationOrganisationName(this ApiContactSpecificationOrganisationName apiContactSpecificationOrganisationName);
    public static partial ContactSpecificationDtoPersonalName ToContactSpecificationPersonalName(this ApiContactSpecificationPersonalName apiContactSpecificationPersonalName);
    public static partial ContactSpecificationDtoPostalAddress ToContactSpecificationPostalAddress(this ApiContactSpecificationPostalAddress apiContactSpecificationPostalAddress);
    public static partial ContactSpecificationDtoBankAccount ToContactSpecificationBankAccount(this ApiContactSpecificationBankAccount apiContactSpecificationBankAccount);
    public static partial ContactSpecificationDtoWebsite ToContactSpecificationWebsite(this ApiContactSpecificationWebsite apiContactSpecificationWebsite);
    public static partial ContactSpecificationDtoPaypal ToContactSpecificationPaypal(this ApiContactSpecificationPaypal apiContactSpecificationPaypal);

    [UserMapping(Default = true)]
    public static ContactSpecificationDto ToContactSpecification(
        this ApiContactSpecification apiContactSpecification) =>
        apiContactSpecification switch
        {
            ApiContactSpecificationPhoneNumber apiContactSpecificationPhoneNumber => apiContactSpecificationPhoneNumber
                .ToContactSpecificationPhoneNumber(),
            ApiContactSpecificationMailAddress apiContactSpecificationMailAddress => apiContactSpecificationMailAddress
                .ToContactSpecificationMailAddress(),
            ApiContactSpecificationOrganisationName apiContactSpecificationOrganisationName => apiContactSpecificationOrganisationName
                .ToContactSpecificationOrganisationName(),
            ApiContactSpecificationPersonalName apiContactSpecificationPersonalName => apiContactSpecificationPersonalName
                .ToContactSpecificationPersonalName(),
            ApiContactSpecificationPostalAddress apiContactSpecificationPostalAddress =>
                apiContactSpecificationPostalAddress.ToContactSpecificationPostalAddress(),
            ApiContactSpecificationBankAccount apiContactSpecificationBankAccount =>
              apiContactSpecificationBankAccount.ToContactSpecificationBankAccount(),
            ApiContactSpecificationWebsite apiContactSpecificationWebsite =>
              apiContactSpecificationWebsite.ToContactSpecificationWebsite(),
            ApiContactSpecificationPaypal apiContactSpecificationPaypal =>
              apiContactSpecificationPaypal.ToContactSpecificationPaypal(),
            _ => apiContactSpecification.ToContactSpecificationInner()
        };

    // To Api
    internal static partial ApiContactSpecification ToApiContactSpecificationInner(this ContactSpecificationDto contactSpecificationDto);
    public static partial ApiContactSpecificationPhoneNumber ToApiContactSpecificationPhoneNumber(this ContactSpecificationDtoPhoneNumber contactSpecificationDtoPhoneNumber);
    public static partial ApiContactSpecificationMailAddress ToApiContactSpecificationMailAddress(this ContactSpecificationDtoMailAddress contactSpecificationDtoMailAddress);
    public static partial ApiContactSpecificationPersonalName ToApiContactSpecificationPersonalName(this ContactSpecificationDtoPersonalName contactSpecificationDtoPersonalName);
    public static partial ApiContactSpecificationOrganisationName ToApiContactSpecificationOrganisationName(this ContactSpecificationDtoOrganisationName contactSpecificationDtoOrganisationName);
    public static partial ApiContactSpecificationPostalAddress ToApiContactSpecificationPostalAddress(this ContactSpecificationDtoPostalAddress contactSpecificationDtoPostalAddress);
    public static partial ApiContactSpecificationBankAccount ToApiContactSpecificationBankAccount(this ContactSpecificationDtoBankAccount contactSpecificationDtoBankAccount);
    public static partial ApiContactSpecificationWebsite ToApiContactSpecificationWebsite(this ContactSpecificationDtoWebsite contactSpecificationDtoWebsite);
    public static partial ApiContactSpecificationPaypal ToApiContactSpecificationPaypal(this ContactSpecificationDtoPaypal contactSpecificationDtoPaypal);

    [UserMapping(Default = true)]
    public static ApiContactSpecification ToApiContactSpecification(
        this ContactSpecificationDto contactSpecificationDto) =>
        contactSpecificationDto switch
        {
            ContactSpecificationDtoPersonalName contactSpecificationPersonalName => contactSpecificationPersonalName
                .ToApiContactSpecificationPersonalName(),
            ContactSpecificationDtoOrganisationName contactSpecificationOrganisationName => contactSpecificationOrganisationName
                .ToApiContactSpecificationOrganisationName(),
            ContactSpecificationDtoPhoneNumber contactSpecificationPhoneNumber => contactSpecificationPhoneNumber
                .ToApiContactSpecificationPhoneNumber(),
            ContactSpecificationDtoMailAddress contactSpecificationMailAddress => contactSpecificationMailAddress
                .ToApiContactSpecificationMailAddress(),
            ContactSpecificationDtoPostalAddress contactSpecificationPostalAddress => contactSpecificationPostalAddress
                .ToApiContactSpecificationPostalAddress(),
            ContactSpecificationDtoBankAccount contactSpecificationBankAccount => contactSpecificationBankAccount
              .ToApiContactSpecificationBankAccount(),
            ContactSpecificationDtoWebsite contactSpecificationWebsite => contactSpecificationWebsite
              .ToApiContactSpecificationWebsite(),
            ContactSpecificationDtoPaypal contactSpecificationPaypal => contactSpecificationPaypal
              .ToApiContactSpecificationPaypal(),
            _ => contactSpecificationDto.ToApiContactSpecificationInner()
        };
}
