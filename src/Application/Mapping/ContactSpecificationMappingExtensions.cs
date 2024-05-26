using Application.Models;
using Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Application.Mapping;


public static partial class ApiMappingExtensions
{
    // From Api
    internal static partial ContactSpecificationDto ToContactSpecificationInner(this ApiContactSpecification apiContactSpecification);
    public static partial ContactSpecificationDtoPhoneNumber ToContactSpecificationPhoneNumber(this ApiContactSpecificationPhoneNumber apiContactSpecificationPhoneNumber);
    public static partial ContactSpecificationDtoMailAddress ToContactSpecificationMailAddress(this ApiContactSpecificationMailAddress apiContactSpecificationMailAddress);
    public static partial ContactSpecificationDtoPostalAddress ToContactSpecificationPostalAddress(this ApiContactSpecificationPostalAddress apiContactSpecificationPostalAddress);

    [UserMapping(Default = true)]
    public static ContactSpecificationDto ToContactSpecification(
        this ApiContactSpecification apiContactSpecification) =>
        apiContactSpecification switch
        {
            ApiContactSpecificationPhoneNumber apiContactSpecificationPhoneNumber => apiContactSpecificationPhoneNumber
                .ToContactSpecificationPhoneNumber(),
            ApiContactSpecificationMailAddress apiContactSpecificationMailAddress => apiContactSpecificationMailAddress
                .ToContactSpecificationMailAddress(),
            ApiContactSpecificationPostalAddress apiContactSpecificationPostalAddress =>
                apiContactSpecificationPostalAddress.ToContactSpecificationPostalAddress(),
            _ => apiContactSpecification.ToContactSpecificationInner()
        };

    // To Api
    internal static partial ApiContactSpecification ToApiContactSpecificationInner(this ContactSpecificationDto contactSpecificationDto);
    public static partial ApiContactSpecificationPhoneNumber ToApiContactSpecificationPhoneNumber(this ContactSpecificationDtoPhoneNumber contactSpecificationDtoPhoneNumber);
    public static partial ApiContactSpecificationMailAddress ToApiContactSpecificationMailAddress(this ContactSpecificationDtoMailAddress contactSpecificationDtoMailAddress);
    public static partial ApiContactSpecificationPostalAddress ToApiContactSpecificationPostalAddress(this ContactSpecificationDtoPostalAddress contactSpecificationDtoPostalAddress);

    [UserMapping(Default = true)]
    public static ApiContactSpecification ToApiContactSpecification(
        this ContactSpecificationDto contactSpecificationDto) =>
        contactSpecificationDto switch
        {
            ContactSpecificationDtoPhoneNumber contactSpecificationPhoneNumber => contactSpecificationPhoneNumber
                .ToApiContactSpecificationPhoneNumber(),
            ContactSpecificationDtoMailAddress contactSpecificationMailAddress => contactSpecificationMailAddress
                .ToApiContactSpecificationMailAddress(),
            ContactSpecificationDtoPostalAddress contactSpecificationPostalAddress => contactSpecificationPostalAddress
                .ToApiContactSpecificationPostalAddress(),
            _ => contactSpecificationDto.ToApiContactSpecificationInner()
        };
}