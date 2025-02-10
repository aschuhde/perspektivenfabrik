using Application.Models.ApiModels;
using Domain.Entities;

namespace Application.Updaters;

public static class LocationSpecificationUpdater
{
    public static void UpdateLocationSpecification(this ApiLocationSpecification entity,
        LocationSpecificationDto? existingItem,
        EntityUpdatingContext updatingContext)
    {
        entity.PrepareBaseEntity(existingItem, updatingContext);
        
        if(updatingContext.IsCreating)
            UpdateChanges(entity, existingItem!, updatingContext);
    }
    
    private static void UpdateChanges(this ApiLocationSpecification entity, LocationSpecificationDto existingItem,
        EntityUpdatingContext updatingContext)
    {
        if(entity is ApiLocationSpecificationAddress locationSpecificationAddress
           && locationSpecificationAddress.PostalAddress.ToString() != (existingItem as LocationSpecificationDtoAddress)?.PostalAddress.ToString())
            updatingContext.AddChange(nameof(ApiLocationSpecificationAddress.PostalAddress), locationSpecificationAddress.PostalAddress.ToString(), (existingItem as LocationSpecificationDtoAddress)?.PostalAddress.ToString());
       
        if(entity is ApiLocationSpecificationCoordinates locationSpecificationCoordinates
           && locationSpecificationCoordinates.Coordinates.ToString() != (existingItem as LocationSpecificationDtoCoordinates)?.Coordinates.ToString())
            updatingContext.AddChange(nameof(ApiLocationSpecificationCoordinates.Coordinates), locationSpecificationCoordinates.Coordinates.ToString(), (existingItem as LocationSpecificationDtoCoordinates)?.Coordinates.ToString());
        
        if(entity is ApiLocationSpecificationRegion locationSpecificationRegion
           && locationSpecificationRegion.Region.ToString() != (existingItem as LocationSpecificationDtoRegion)?.Region.ToString())
            updatingContext.AddChange(nameof(ApiLocationSpecificationRegion.Region), locationSpecificationRegion.Region.ToString(), (existingItem as LocationSpecificationDtoRegion)?.Region.ToString());
        
        if(entity is ApiLocationSpecificationRemote locationSpecificationRemote
           && locationSpecificationRemote.Link.ToString() != (existingItem as LocationSpecificationDtoRemote)?.Link.ToString())
            updatingContext.AddChange(nameof(ApiLocationSpecificationRemote.Link), locationSpecificationRemote.Link.ToString(), (existingItem as LocationSpecificationDtoRemote)?.Link.ToString());
    }
}
