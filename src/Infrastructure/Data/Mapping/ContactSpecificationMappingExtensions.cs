using Domain.Entities;
using Infrastructure.Data.DbEntities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;


public static partial class MappingExtensions
{
    // From DB
    internal static partial ContactSpecificationDto ToContactSpecificationInner(this DbContactSpecification dbContactSpecification);
    public static partial ContactSpecificationDtoPhoneNumber ToContactSpecificationPhoneNumber(this DbContactSpecificationPhoneNumber dbContactSpecificationPhoneNumber);
    public static partial ContactSpecificationDtoMailAddress ToContactSpecificationMailAddress(this DbContactSpecificationMailAddress dbContactSpecificationMailAddress);
    public static partial ContactSpecificationDtoPostalAddress ToContactSpecificationPostalAddress(this DbContactSpecificationPostalAddress dbContactSpecificationPostalAddress);

    [UserMapping(Default = true)]
    public static ContactSpecificationDto ToContactSpecification(
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
    internal static partial DbContactSpecification ToDbContactSpecificationInner(this ContactSpecificationDto contactSpecificationDto);
    public static partial DbContactSpecificationPhoneNumber ToDbContactSpecificationPhoneNumber(this ContactSpecificationDtoPhoneNumber contactSpecificationDtoPhoneNumber);
    public static partial DbContactSpecificationMailAddress ToDbContactSpecificationMailAddress(this ContactSpecificationDtoMailAddress contactSpecificationDtoMailAddress);
    public static partial DbContactSpecificationPostalAddress ToDbContactSpecificationPostalAddress(this ContactSpecificationDtoPostalAddress contactSpecificationDtoPostalAddress);

    [UserMapping(Default = true)]
    public static DbContactSpecification ToDbContactSpecification(
        this ContactSpecificationDto contactSpecificationDto) =>
        contactSpecificationDto switch
        {
            ContactSpecificationDtoPhoneNumber contactSpecificationPhoneNumber => contactSpecificationPhoneNumber
                .ToDbContactSpecificationPhoneNumber(),
            ContactSpecificationDtoMailAddress contactSpecificationMailAddress => contactSpecificationMailAddress
                .ToDbContactSpecificationMailAddress(),
            ContactSpecificationDtoPostalAddress contactSpecificationPostalAddress => contactSpecificationPostalAddress
                .ToDbContactSpecificationPostalAddress(),
            _ => contactSpecificationDto.ToDbContactSpecificationInner()
        };
}