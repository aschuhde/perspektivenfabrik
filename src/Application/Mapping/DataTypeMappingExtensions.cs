using Application.ApiDataTypes;
using Domain.DataTypes;

namespace Application.Mapping;


public static partial class ApiMappingExtensions
{
    public static partial Coordinates ToCoordinates(this ApiCoordinates apiCoordinates);
    public static partial ApiCoordinates ToApiCoordinates(this Coordinates coordinates);
    
    public static partial FormattedContent ToFormattedContent(this ApiFormattedContent apiFormattedContent);
    public static partial ApiFormattedContent ToApiFormattedContent(this FormattedContent formattedContent);
    
    public static partial FormattedTitle ToFormattedTitle(this ApiFormattedTitle apiFormattedTitle);
    public static partial ApiFormattedTitle ToApiFormattedTitle(this FormattedTitle formattedTitle);
    
    public static partial GraphicsContent ToGraphicsContent(this ApiGraphicsContent apiGraphicsContent);
    public static partial ApiGraphicsContent ToApiGraphicsContent(this GraphicsContent graphicsContent);
    
    public static partial MailAddress ToMailAddress(this ApiMailAddress apiMailAddress);
    public static partial ApiMailAddress ToApiMailAddress(this MailAddress mailAddress);
    
    public static partial Month ToMonth(this ApiMonth apiMonth);
    public static partial ApiMonth ToApiMonth(this Month month);
    
    public static partial OrganizationPosition ToOrganizationPosition(this ApiOrganizationPosition apiOrganizationPosition);
    
    public static partial ApiOrganizationPosition ToApiOrganizationPosition(
        this OrganizationPosition organizationPosition);
    
    public static partial PhoneNumber ToPhoneNumber(this ApiPhoneNumber apiPhoneNumber);
    public static partial ApiPhoneNumber ToApiPhoneNumber(this PhoneNumber phoneNumber);
    
    public static partial PostalAddress ToPostalAddress(this ApiPostalAddress apiPostalAddress);
    public static partial ApiPostalAddress ToApiPostalAddress(this PostalAddress postalAddress);
    
    public static partial Region ToRegion(this ApiRegion apiRegion);
    public static partial ApiRegion ToApiRegion(this Region region);
    
    public static partial Year ToYear(this ApiYear apiYear);
    public static partial ApiYear ToApiYear(this Year year);
}