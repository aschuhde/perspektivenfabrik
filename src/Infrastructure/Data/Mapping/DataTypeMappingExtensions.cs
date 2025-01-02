using Domain.DataTypes;
using Infrastructure.Data.DbDataTypes;

namespace Infrastructure.Data.Mapping;


public static partial class MappingExtensions
{
    public static partial Coordinates ToCoordinates(this DbCoordinates dbCoordinates);
    public static partial DbCoordinates ToDbCoordinates(this Coordinates coordinates);
    
    public static partial FormattedContent ToFormattedContent(this DbFormattedContent dbFormattedContent);
    public static partial DbFormattedContent ToDbFormattedContent(this FormattedContent formattedContent);
    
    public static partial FormattedTitle ToFormattedTitle(this DbFormattedTitle dbFormattedTitle);
    public static partial DbFormattedTitle ToDbFormattedTitle(this FormattedTitle formattedTitle);
    
    public static partial GraphicsContent ToGraphicsContent(this DbGraphicsContent dbGraphicsContent);
    public static partial DbGraphicsContent ToDbGraphicsContent(this GraphicsContent graphicsContent);
    
    public static partial MailAddress ToMailAddress(this DbMailAddress dbMailAddress);
    public static partial DbMailAddress ToDbMailAddress(this MailAddress mailAddress);
    
    public static partial Month ToMonth(this DbMonth dbMonth);
    public static partial DbMonth ToDbMonth(this Month month);
    
    public static partial OrganizationPosition ToOrganizationPosition(this DbOrganizationPosition dbOrganizationPosition);
    
    public static partial DbOrganizationPosition ToDbOrganizationPosition(
        this OrganizationPosition organizationPosition);
    
    public static partial PhoneNumber ToPhoneNumber(this DbPhoneNumber dbPhoneNumber);
    public static partial DbPhoneNumber ToDbPhoneNumber(this PhoneNumber phoneNumber);
    
    public static partial PostalAddress ToPostalAddress(this DbPostalAddress dbPostalAddress);
    public static partial DbPostalAddress ToDbPostalAddress(this PostalAddress postalAddress);
    
    public static partial Region ToRegion(this DbRegion dbRegion);
    public static partial DbRegion ToDbRegion(this Region region);
    
    public static partial Year ToYear(this DbYear dbYear);
    public static partial DbYear ToDbYear(this Year year);
}