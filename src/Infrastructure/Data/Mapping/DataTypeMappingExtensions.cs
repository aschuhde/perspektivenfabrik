using Domain.DataTypes;
using Infrastructure.Data.DbDataTypes;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;


public static partial class MappingExtensions
{
    public static partial Coordinates ToCoordinates(this DbCoordinates dbCoordinates);
    public static partial DbCoordinates ToDbCoordinates(this Coordinates coordinates);
    
    [MapperIgnoreTarget(nameof(FormattedContent.ContentTranslations))]
    public static partial FormattedContent ToFormattedContent(this DbFormattedContent dbFormattedContent);
    [MapperIgnoreSource(nameof(FormattedContent.ContentTranslations))]
    public static partial DbFormattedContent ToDbFormattedContent(this FormattedContent formattedContent);
    
    [MapperIgnoreTarget(nameof(FormattedTitle.ContentTranslations))]
    public static partial FormattedTitle ToFormattedTitle(this DbFormattedTitle dbFormattedTitle);
    [MapperIgnoreSource(nameof(FormattedTitle.ContentTranslations))]
    public static partial DbFormattedTitle ToDbFormattedTitle(this FormattedTitle formattedTitle);
    
    public static partial GraphicsContent ToGraphicsContent(this DbGraphicsContent dbGraphicsContent);
    public static partial DbGraphicsContent ToDbGraphicsContent(this GraphicsContent graphicsContent);
    
    [MapperIgnoreTarget(nameof(MailAddress.MailTranslations))]
    public static partial MailAddress ToMailAddress(this DbMailAddress dbMailAddress);
    [MapperIgnoreSource(nameof(MailAddress.MailTranslations))]
    public static partial DbMailAddress ToDbMailAddress(this MailAddress mailAddress);
    
    [MapperIgnoreTarget(nameof(BankAccount.AccountNameTranslations))]
    [MapperIgnoreTarget(nameof(BankAccount.ReferenceTranslations))]
    public static partial BankAccount ToBankAccount(this DbBankAccount dbBankAccount);
    [MapperIgnoreSource(nameof(BankAccount.AccountNameTranslations))]
    [MapperIgnoreSource(nameof(BankAccount.ReferenceTranslations))]
    public static partial DbBankAccount ToDbBankAccount(this BankAccount bankAccount);
    
    public static partial Iban ToIban(this DbIban dbIban);
    public static partial DbIban ToDbIban(this Iban iban);
    
    public static partial Bic ToBic(this DbBic dbBic);
    public static partial DbBic ToDbBic(this Bic bic);
    
    public static partial Month ToMonth(this DbMonth dbMonth);
    public static partial DbMonth ToDbMonth(this Month month);
    
    [MapperIgnoreTarget(nameof(Url.UrlTranslations))]
    public static partial Url ToUrl(this DbUrl dbUrl);
    [MapperIgnoreSource(nameof(Url.UrlTranslations))]
    public static partial DbUrl ToDbUrl(this Url url);
    
    public static partial OrganizationPosition ToOrganizationPosition(this DbOrganizationPosition dbOrganizationPosition);
    
    public static partial DbOrganizationPosition ToDbOrganizationPosition(
        this OrganizationPosition organizationPosition);
    
    [MapperIgnoreTarget(nameof(PhoneNumber.PhoneNumberTextTranslations))]
    public static partial PhoneNumber ToPhoneNumber(this DbPhoneNumber dbPhoneNumber);
    [MapperIgnoreSource(nameof(PhoneNumber.PhoneNumberTextTranslations))]
    public static partial DbPhoneNumber ToDbPhoneNumber(this PhoneNumber phoneNumber);
    
    [MapperIgnoreTarget(nameof(PostalAddress.AddressDisplayNameTranslations))]
    [MapperIgnoreTarget(nameof(PostalAddress.AddressTextTranslations))]
    public static partial PostalAddress ToPostalAddress(this DbPostalAddress dbPostalAddress);
    [MapperIgnoreSource(nameof(PostalAddress.AddressDisplayNameTranslations))]
    [MapperIgnoreSource(nameof(PostalAddress.AddressTextTranslations))]
    public static partial DbPostalAddress ToDbPostalAddress(this PostalAddress postalAddress);
    
    [MapperIgnoreTarget(nameof(Region.AddressTextTranslations))]
    [MapperIgnoreTarget(nameof(Region.RegionNameTranslations))]
    public static partial Region ToRegion(this DbRegion dbRegion);
    [MapperIgnoreSource(nameof(Region.AddressTextTranslations))]
    [MapperIgnoreSource(nameof(Region.RegionNameTranslations))]
    public static partial DbRegion ToDbRegion(this Region region);
    
    public static partial Year ToYear(this DbYear dbYear);
    public static partial DbYear ToDbYear(this Year year);
}
