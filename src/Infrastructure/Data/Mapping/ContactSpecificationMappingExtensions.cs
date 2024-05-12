using Domain.Entities;
using Infrastructure.Data.DbEntities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;

[Mapper]
public static partial class ContactSpecificationMappingExtensions
{
    // From DB
    public static partial ContactSpecification ToContactSpecificationInner(this DbContactSpecification dbContactSpecification);
    public static partial ContactSpecificationPhoneNumber ToContactSpecificationPhoneNumber(this DbContactSpecificationPhoneNumber dbContactSpecificationPhoneNumber);
    public static partial ContactSpecificationMailAddress ToContactSpecificationMailAddress(this DbContactSpecificationMailAddress dbContactSpecificationMailAddress);
    public static partial ContactSpecificationPostalAddress ToContactSpecificationPostalAddress(this DbContactSpecificationPostalAddress dbContactSpecificationPostalAddress);

    [UserMapping(Default = true)]
    public static ContactSpecification ToContactSpecification(
        this DbContactSpecification dbContactSpecification) =>
        dbContactSpecification switch
        {
            DbContactSpecificationPhoneNumber dbContactSpecificationPhoneNumber => dbContactSpecificationPhoneNumber
                .ToContactSpecificationPhoneNumber(),
            DbContactSpecificationMailAddress dbContactSpecificationMailAddress => dbContactSpecificationMailAddress
                .ToContactSpecificationMailAddress(),
            DbContactSpecificationPostalAddress dbContactSpecificationPostalAddress =>
                dbContactSpecificationPostalAddress.ToContactSpecificationPostalAddress(),
            _ => dbContactSpecification.ToContactSpecificationInner()
        };

    // To DB
    public static partial DbContactSpecification ToDbContactSpecificationInner(this ContactSpecification contactSpecification);
    public static partial DbContactSpecificationPhoneNumber ToDbContactSpecificationPhoneNumber(this ContactSpecificationPhoneNumber contactSpecificationPhoneNumber);
    public static partial DbContactSpecificationMailAddress ToDbContactSpecificationMailAddress(this ContactSpecificationMailAddress contactSpecificationMailAddress);
    public static partial DbContactSpecificationPostalAddress ToDbContactSpecificationPostalAddress(this ContactSpecificationPostalAddress contactSpecificationPostalAddress);

    [UserMapping(Default = true)]
    public static DbContactSpecification ToDbContactSpecification(
        this ContactSpecification contactSpecification) =>
        contactSpecification switch
        {
            ContactSpecificationPhoneNumber contactSpecificationPhoneNumber => contactSpecificationPhoneNumber
                .ToDbContactSpecificationPhoneNumber(),
            ContactSpecificationMailAddress contactSpecificationMailAddress => contactSpecificationMailAddress
                .ToDbContactSpecificationMailAddress(),
            ContactSpecificationPostalAddress contactSpecificationPostalAddress => contactSpecificationPostalAddress
                .ToDbContactSpecificationPostalAddress(),
            _ => contactSpecification.ToDbContactSpecificationInner()
        };
}