using Domain.DataTypes;

namespace Domain.Entities;

public class LocationSpecificationDto : BaseEntityWithIdDto
{
    public virtual void ApplyTranslations(FieldTranslationDto[] fieldTranslations)
    {
        
    }
}

public sealed class LocationSpecificationDtoRemote : LocationSpecificationDto
{
    public required Url Link { get; init; }
    
    public override void ApplyTranslations(FieldTranslationDto[] fieldTranslations)
    {
        Link.UrlTranslations = fieldTranslations.Where(x => x.CorrelatedEntityId == x.EntityId && x.PropertyPath == nameof(Link)).Select(x => x.ToTranslationValue()).ToArray(); 
    }
}

public sealed class LocationSpecificationDtoRegion : LocationSpecificationDto
{
    public required Region Region { get; init; }
    
    public override void ApplyTranslations(FieldTranslationDto[] fieldTranslations)
    {
        var translations = fieldTranslations.Where(x => x.CorrelatedEntityId == x.EntityId).ToArray();
        Region.AddressTextTranslations = translations.Where(x => x.PropertyPath == nameof(Region.AddressText)).Select(x => x.ToTranslationValue()).ToArray(); 
        Region.RegionNameTranslations = translations.Where(x => x.PropertyPath == nameof(Region.RegionName)).Select(x => x.ToTranslationValue()).ToArray(); 
    }
}

public sealed class LocationSpecificationDtoCoordinates : LocationSpecificationDto
{
    public required Coordinates Coordinates { get; init; }
}

public sealed class LocationSpecificationDtoAddress : LocationSpecificationDto
{
    public required PostalAddress PostalAddress { get; init; }
    
    public override void ApplyTranslations(FieldTranslationDto[] fieldTranslations)
    {
        var translations = fieldTranslations.Where(x => x.CorrelatedEntityId == x.EntityId).ToArray();
        PostalAddress.AddressTextTranslations = translations.Where(x => x.PropertyPath == nameof(PostalAddress.AddressDisplayName)).Select(x => x.ToTranslationValue()).ToArray(); 
        PostalAddress.AddressDisplayNameTranslations = translations.Where(x => x.PropertyPath == nameof(PostalAddress.AddressDisplayName)).Select(x => x.ToTranslationValue()).ToArray(); 
    }
}