using Application.Models.ApiModels;
using Domain.Entities;

namespace Application.Updaters;

public static class ContactSpecificationUpdater
{
    public static void UpdateContactSpecification(this ApiContactSpecification entity,
        ContactSpecificationDto? existingItem,
        EntityUpdatingContext updatingContext)
    {
        if(updatingContext.IsCreating)
            UpdateChanges(entity, existingItem!, updatingContext);
        
        entity.UpdateBaseEntity(existingItem, updatingContext);
    }

    private static void UpdateChanges(this ApiContactSpecification entity, ContactSpecificationDto existingItem,
        EntityUpdatingContext updatingContext)
    {
        if(entity is ApiContactSpecificationMailAddress contactSpecificationMailAddress
           && contactSpecificationMailAddress.MailAddress != (existingItem as ContactSpecificationDtoMailAddress)?.MailAddress)
            updatingContext.AddChange(nameof(ApiContactSpecificationMailAddress.MailAddress), contactSpecificationMailAddress.MailAddress.ToString(), (existingItem as ContactSpecificationDtoMailAddress)?.MailAddress.ToString());
        
        if(entity is ApiContactSpecificationPhoneNumber contactSpecificationPhoneNumber
           && contactSpecificationPhoneNumber.PhoneNumber.PhoneNumberText != (existingItem as ContactSpecificationDtoPhoneNumber)?.PhoneNumber.PhoneNumberText)
            updatingContext.AddChange(nameof(ApiContactSpecificationPhoneNumber.PhoneNumber), contactSpecificationPhoneNumber.PhoneNumber.PhoneNumberText, (existingItem as ContactSpecificationDtoPhoneNumber)?.PhoneNumber.PhoneNumberText);
        
        if(entity is ApiContactSpecificationPostalAddress contactSpecificationPostalAddress
           && contactSpecificationPostalAddress.PostalAddress.ToString() != (existingItem as ContactSpecificationDtoPostalAddress)?.PostalAddress.ToString())
            updatingContext.AddChange(nameof(ApiContactSpecificationPostalAddress.PostalAddress), contactSpecificationPostalAddress.PostalAddress.ToString(), (existingItem as ContactSpecificationDtoPostalAddress)?.PostalAddress.ToString());
    }
}
