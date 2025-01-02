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

        entity.UpdateBaseEntity(existingItem, updatingContext);
    }
    
    private static void UpdateChanges(this ApiLocationSpecification entity, LocationSpecificationDto existingItem,
        EntityUpdatingContext updatingContext)
    {
        if(entity is ApiLocationSpecificationAddress locationSpecificationAddress
           && locationSpecificationAddress.PostalAddress.ToString() != (existingItem as LocationSpecificationDtoAddress)?.PostalAddress.ToString())
            updatingContext.AddChange(nameof(ApiContactSpecificationMailAddress.MailAddress), locationSpecificationAddress.PostalAddress.ToString(), (existingItem as LocationSpecificationDtoAddress)?.PostalAddress.ToString());
        //continue here        
        if(entity is ApiLocationSpecificationCoordinates contactSpecificationPhoneNumber
           && contactSpecificationPhoneNumber.PhoneNumber.PhoneNumberText != (existingItem as ContactSpecificationDtoPhoneNumber)?.PhoneNumber.PhoneNumberText)
            updatingContext.AddChange(nameof(ApiContactSpecificationPhoneNumber.PhoneNumber), contactSpecificationPhoneNumber.PhoneNumber.PhoneNumberText, (existingItem as ContactSpecificationDtoPhoneNumber)?.PhoneNumber.PhoneNumberText);
        
        if(entity is ApiLocationSpecificationRegion contactSpecificationPostalAddress
           && contactSpecificationPostalAddress.PostalAddress.ToString() != (existingItem as ContactSpecificationDtoPostalAddress)?.PostalAddress.ToString())
            updatingContext.AddChange(nameof(ApiContactSpecificationPostalAddress.PostalAddress), contactSpecificationPostalAddress.PostalAddress.ToString(), (existingItem as ContactSpecificationDtoPostalAddress)?.PostalAddress.ToString());
        
        if(entity is ApiLocationSpecificationRemote contactSpecificationPostalAddress
           && contactSpecificationPostalAddress.PostalAddress.ToString() != (existingItem as ContactSpecificationDtoPostalAddress)?.PostalAddress.ToString())
            updatingContext.AddChange(nameof(ApiContactSpecificationPostalAddress.PostalAddress), contactSpecificationPostalAddress.PostalAddress.ToString(), (existingItem as ContactSpecificationDtoPostalAddress)?.PostalAddress.ToString());
    }
}
