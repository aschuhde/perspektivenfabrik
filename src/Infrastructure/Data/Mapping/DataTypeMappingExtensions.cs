using Domain.DataTypes;
using Infrastructure.Data.DbDataTypes;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;

[Mapper]
public static partial class DataTypeMappingExtensions
{
        public static partial Coordinates ToCoordinates(this DbCoordinates dbCoordinates);
    public static partial DbCoordinates ToDbCoordinates(this Coordinates Coordinates);
    
    public static partial FormattedContent ToFormattedContent(this DbFormattedContent dbFormattedContent);
    public static partial DbFormattedContent ToDbFormattedContent(this FormattedContent FormattedContent);
    
    public static partial FormattedTitle ToFormattedTitle(this DbFormattedTitle dbFormattedTitle);
    public static partial DbFormattedTitle ToDbFormattedTitle(this FormattedTitle FormattedTitle);
    
    public static partial GraphicsContent ToGraphicsContent(this DbGraphicsContent dbGraphicsContent);
    public static partial DbGraphicsContent ToDbGraphicsContent(this GraphicsContent GraphicsContent);
    
    public static partial MailAddress ToMailAddress(this DbMailAddress dbMailAddress);
    public static partial DbMailAddress ToDbMailAddress(this MailAddress MailAddress);
    
    public static partial Month ToMonth(this DbMonth dbMonth);
    public static partial DbMonth ToDbMonth(this Month Month);
    
    public static partial OrganizationPosition ToOrganizationPosition(this DbOrganizationPosition dbOrganizationPosition);
    
    public static partial DbOrganizationPosition ToDbOrganizationPosition(
        this OrganizationPosition OrganizationPosition);
    
    public static partial PhoneNumber ToPhoneNumber(this DbPhoneNumber dbPhoneNumber);
    public static partial DbPhoneNumber ToDbPhoneNumber(this PhoneNumber PhoneNumber);
    
    public static partial PostalAddress ToPostalAddress(this DbPostalAddress dbPostalAddress);
    public static partial DbPostalAddress ToDbPostalAddress(this PostalAddress PostalAddress);
    
    public static partial Region ToRegion(this DbRegion dbRegion);
    public static partial DbRegion ToDbRegion(this Region Region);
    
    public static partial Year ToYear(this DbYear dbYear);
    public static partial DbYear ToDbYear(this Year Year);
}