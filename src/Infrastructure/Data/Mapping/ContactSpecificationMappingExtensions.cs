using Domain.Entities;
using Infrastructure.Data.DbEntities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;


public static partial class MappingExtensions
{
    // From DB
    internal static partial ContactSpecificationDto ToContactSpecificationInner(this DbContactSpecification dbContactSpecification);
    public static partial ContactSpecificationDtoPhoneNumber ToContactSpecificationPhoneNumber(this DbContactSpecificationPhoneNumber dbContactSpecificationPhoneNumber);
    public static partial ContactSpecificationDtoPersonalName ToContactSpecificationPersonalName(this DbContactSpecificationPersonalName dbContactSpecificationPersonalName);
    public static partial ContactSpecificationDtoOrganisationName ToContactSpecificationOrganisationName(this DbContactSpecificationOrganisationName dbContactSpecificationOrganisationName);
    public static partial ContactSpecificationDtoMailAddress ToContactSpecificationMailAddress(this DbContactSpecificationMailAddress dbContactSpecificationMailAddress);
    public static partial ContactSpecificationDtoPostalAddress ToContactSpecificationPostalAddress(this DbContactSpecificationPostalAddress dbContactSpecificationPostalAddress);
    public static partial ContactSpecificationDtoBankAccount ToContactSpecificationBankAccount(this DbContactSpecificationBankAccount dbContactSpecificationBankAccount);
    public static partial ContactSpecificationDtoWebsite ToContactSpecificationWebsite(this DbContactSpecificationWebsite dbContactSpecificationWebsite);
    public static partial ContactSpecificationDtoPaypal ToContactSpecificationPaypal(this DbContactSpecificationPaypal dbContactSpecificationPaypal);

    [UserMapping(Default = true)]
    public static ContactSpecificationDto ToContactSpecification(
        this DbContactSpecification dbContactSpecification) =>
        dbContactSpecification switch
        {
            DbContactSpecificationPhoneNumber dbContactSpecificationPhoneNumber => dbContactSpecificationPhoneNumber
                .ToContactSpecificationPhoneNumber(),
            DbContactSpecificationPersonalName dbContactSpecificationPersonalName => dbContactSpecificationPersonalName
                .ToContactSpecificationPersonalName(),
            DbContactSpecificationOrganisationName dbContactSpecificationOrganisationName => dbContactSpecificationOrganisationName
                .ToContactSpecificationOrganisationName(),
            DbContactSpecificationMailAddress dbContactSpecificationMailAddress => dbContactSpecificationMailAddress
                .ToContactSpecificationMailAddress(),
            DbContactSpecificationPostalAddress dbContactSpecificationPostalAddress =>
                dbContactSpecificationPostalAddress.ToContactSpecificationPostalAddress(),
            DbContactSpecificationBankAccount dbContactSpecificationBankAccount =>
              dbContactSpecificationBankAccount.ToContactSpecificationBankAccount(),
            DbContactSpecificationWebsite dbContactSpecificationWebsite =>
              dbContactSpecificationWebsite.ToContactSpecificationWebsite(),
            DbContactSpecificationPaypal dbContactSpecificationPaypal =>
              dbContactSpecificationPaypal.ToContactSpecificationPaypal(),
            _ => dbContactSpecification.ToContactSpecificationInner()
        };

    // To DB
    internal static partial DbContactSpecification ToDbContactSpecificationInner(this ContactSpecificationDto contactSpecificationDto);
    public static partial DbContactSpecificationPhoneNumber ToDbContactSpecificationPhoneNumber(this ContactSpecificationDtoPhoneNumber contactSpecificationDtoPhoneNumber);
    public static partial DbContactSpecificationPersonalName ToDbContactSpecificationPersonalName(this ContactSpecificationDtoPersonalName contactSpecificationDtoPersonalName);
    public static partial DbContactSpecificationOrganisationName ToDbContactSpecificationOrganisationName(this ContactSpecificationDtoOrganisationName contactSpecificationDtoOrganisationName);
    public static partial DbContactSpecificationMailAddress ToDbContactSpecificationMailAddress(this ContactSpecificationDtoMailAddress contactSpecificationDtoMailAddress);
    public static partial DbContactSpecificationPostalAddress ToDbContactSpecificationPostalAddress(this ContactSpecificationDtoPostalAddress contactSpecificationDtoPostalAddress);
    public static partial DbContactSpecificationBankAccount ToDbContactSpecificationBankAccount(this ContactSpecificationDtoBankAccount contactSpecificationDtoBankAccount);
    public static partial DbContactSpecificationWebsite ToDbContactSpecificationWebsite(this ContactSpecificationDtoWebsite contactSpecificationDtoWebsite);
    public static partial DbContactSpecificationPaypal ToDbContactSpecificationPaypal(this ContactSpecificationDtoPaypal contactSpecificationDtoPaypal);

    [UserMapping(Default = true)]
    public static DbContactSpecification ToDbContactSpecification(
        this ContactSpecificationDto contactSpecificationDto) =>
        contactSpecificationDto switch
        {
            ContactSpecificationDtoPhoneNumber contactSpecificationPhoneNumber => contactSpecificationPhoneNumber
                .ToDbContactSpecificationPhoneNumber(),
            ContactSpecificationDtoPersonalName contactSpecificationPersonalName => contactSpecificationPersonalName
                .ToDbContactSpecificationPersonalName(),
            ContactSpecificationDtoOrganisationName contactSpecificationOrganisationName => contactSpecificationOrganisationName
                .ToDbContactSpecificationOrganisationName(),
            ContactSpecificationDtoMailAddress contactSpecificationMailAddress => contactSpecificationMailAddress
                .ToDbContactSpecificationMailAddress(),
            ContactSpecificationDtoPostalAddress contactSpecificationPostalAddress => contactSpecificationPostalAddress
                .ToDbContactSpecificationPostalAddress(),
            ContactSpecificationDtoBankAccount contactSpecificationBankAccount => contactSpecificationBankAccount
              .ToDbContactSpecificationBankAccount(),
            ContactSpecificationDtoWebsite contactSpecificationWebsite => contactSpecificationWebsite
              .ToDbContactSpecificationWebsite(),
            ContactSpecificationDtoPaypal contactSpecificationPaypal => contactSpecificationPaypal
              .ToDbContactSpecificationPaypal(),
            _ => contactSpecificationDto.ToDbContactSpecificationInner()
        };
}
