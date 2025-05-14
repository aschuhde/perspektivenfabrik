using Domain.DataTypes;
using Domain.Extensions;

namespace Domain.Entities;

public class LocationSpecificationDto : BaseEntityWithIdDto
{
    public virtual void ApplyTranslations(FieldTranslationDto[] fieldTranslations)
    {
        
    }

    public virtual FieldTranslationDto[] CollectTranslations(Guid projectId)
    {
        return [];
    }
}

public sealed class LocationSpecificationDtoRemote : LocationSpecificationDto
{
    public required Url Link { get; init; }
    
    public override void ApplyTranslations(FieldTranslationDto[] fieldTranslations)
    {
        Link.UrlTranslations = fieldTranslations.Where(x => x.CorrelatedEntityId == EntityId && x.PropertyPath == nameof(Link)).Select(x => x.ToTranslationValue()).ToArray(); 
    }
    public override FieldTranslationDto[] CollectTranslations(Guid projectId)
    {
        return Link.UrlTranslations.CreateFieldTranslationDtos(projectId, EntityId, nameof(Link));
    }
}

public sealed class LocationSpecificationDtoRegion : LocationSpecificationDto
{
    public required Region Region { get; init; }
    
    public override void ApplyTranslations(FieldTranslationDto[] fieldTranslations)
    {
        var translations = fieldTranslations.Where(x => x.CorrelatedEntityId == EntityId).ToArray();
        Region.AddressTextTranslations = translations.Where(x => x.PropertyPath == nameof(Region.AddressText)).Select(x => x.ToTranslationValue()).ToArray(); 
        Region.RegionNameTranslations = translations.Where(x => x.PropertyPath == nameof(Region.RegionName)).Select(x => x.ToTranslationValue()).ToArray(); 
    }
    public override FieldTranslationDto[] CollectTranslations(Guid projectId)
    {
        var result = new List<FieldTranslationDto>();
        result.AddRange(Region.AddressTextTranslations.CreateFieldTranslationDtos(projectId, EntityId, nameof(Region.AddressText)));
        result.AddRange(Region.RegionNameTranslations.CreateFieldTranslationDtos(projectId, EntityId, nameof(Region.RegionName)));
        return result.ToArray();
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
        var translations = fieldTranslations.Where(x => x.CorrelatedEntityId == EntityId).ToArray();
        PostalAddress.AddressTextTranslations = translations.Where(x => x.PropertyPath == nameof(PostalAddress.AddressText)).Select(x => x.ToTranslationValue()).ToArray(); 
        PostalAddress.AddressDisplayNameTranslations = translations.Where(x => x.PropertyPath == nameof(PostalAddress.AddressDisplayName)).Select(x => x.ToTranslationValue()).ToArray(); 
    }
    public override FieldTranslationDto[] CollectTranslations(Guid projectId)
    {
        var result = new List<FieldTranslationDto>();
        result.AddRange(PostalAddress.AddressTextTranslations.CreateFieldTranslationDtos(projectId, EntityId, nameof(PostalAddress.AddressText)));
        result.AddRange(PostalAddress.AddressDisplayNameTranslations.CreateFieldTranslationDtos(projectId, EntityId, nameof(PostalAddress.AddressDisplayName)));
        return result.ToArray();
    }
}

public sealed class LocationSpecificationDtoName : LocationSpecificationDto
{
    public required PostalAddress PostalAddress { get; init; }
    
    public override void ApplyTranslations(FieldTranslationDto[] fieldTranslations)
    {
        var translations = fieldTranslations.Where(x => x.CorrelatedEntityId == EntityId).ToArray();
        PostalAddress.AddressTextTranslations = translations.Where(x => x.PropertyPath == nameof(PostalAddress.AddressText)).Select(x => x.ToTranslationValue()).ToArray(); 
        PostalAddress.AddressDisplayNameTranslations = translations.Where(x => x.PropertyPath == nameof(PostalAddress.AddressDisplayName)).Select(x => x.ToTranslationValue()).ToArray(); 
    }
    public override FieldTranslationDto[] CollectTranslations(Guid projectId)
    {
        var result = new List<FieldTranslationDto>();
        result.AddRange(PostalAddress.AddressTextTranslations.CreateFieldTranslationDtos(projectId, EntityId, nameof(PostalAddress.AddressText)));
        result.AddRange(PostalAddress.AddressDisplayNameTranslations.CreateFieldTranslationDtos(projectId, EntityId, nameof(PostalAddress.AddressDisplayName)));
        return result.ToArray();
    }
}

public sealed class LocationSpecificationDtoEntireProvince : LocationSpecificationDto
{
    
}