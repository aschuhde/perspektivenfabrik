using Application.Models.ApiModels;
using Domain.Entities;

namespace Application.Updaters;

public static class LocationSpecificationUpdater
{
    public static void UpdateLocationSpecification(this ApiLocationSpecification entity,
        LocationSpecificationDto? existingItem,
        EntityUpdatingContext updatingContext)
    {
        if(updatingContext.IsCreating)
            UpdateChanges(entity, existingItem!, updatingContext);

        entity.PrepareBaseEntity(existingItem, updatingContext);
    }
    
    private static void UpdateChanges(this ApiLocationSpecification entity, LocationSpecificationDto existingItem,
        EntityUpdatingContext updatingContext)
    {
        if(entity is ApiLocationSpecificationAddress locationSpecificationAddress
           && locationSpecificationAddress.PostalAddress.ToString() != (existingItem as LocationSpecificationDtoAddress)?.PostalAddress.ToString())
            updatingContext.AddChange(nameof(ApiContactSpecificationMailAddress.MailAddress), locationSpecificationAddress.PostalAddress.ToString(), (existingItem as LocationSpecificationDtoAddress)?.PostalAddress.ToString());
                
        if(entity is ApiLocationSpecificationCoordinates contactSpecificationCoordinates
           && contactSpecificationCoordinates.Coordinates.ToString() != (existingItem as LocationSpecificationDtoCoordinates)?.Coordinates.ToString())
            updatingContext.AddChange(nameof(ApiLocationSpecificationCoordinates.Coordinates), contactSpecificationCoordinates.Coordinates.ToString(), (existingItem as LocationSpecificationDtoCoordinates)?.Coordinates.ToString());
        
        if(entity is ApiLocationSpecificationRegion contactSpecificationRegion
           && contactSpecificationRegion.Region.ToString() != (existingItem as LocationSpecificationDtoRegion)?.Region.ToString())
            updatingContext.AddChange(nameof(ApiLocationSpecificationRegion.Region), contactSpecificationRegion.Region.ToString(), (existingItem as LocationSpecificationDtoRegion)?.Region.ToString());
    }
}
