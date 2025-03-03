using Application.Models.ApiModels;
using Domain.Entities;

namespace Application.Updaters;

public static class ContactSpecificationUpdater
{
    public static void UpdateContactSpecification(this ApiContactSpecification entity,
        ContactSpecificationDto? existingItem,
        EntityUpdatingContext updatingContext)
    {
        if(existingItem != null)
            UpdateChanges(entity, existingItem, updatingContext);
        
        entity.PrepareBaseEntity(existingItem, updatingContext);
    }

    private static void UpdateChanges(this ApiContactSpecification entity, ContactSpecificationDto existingItem,
        EntityUpdatingContext updatingContext)
    {
        if(entity is ApiContactSpecificationMailAddress contactSpecificationMailAddress
           && contactSpecificationMailAddress.MailAddress != (existingItem as ContactSpecificationDtoMailAddress)?.MailAddress)
            updatingContext.AddChange(nameof(ApiContactSpecificationMailAddress.MailAddress), contactSpecificationMailAddress.MailAddress.ToString(), (existingItem as ContactSpecificationDtoMailAddress)?.MailAddress.ToString());
        
        if(entity is ApiContactSpecificationOrganisationName contactSpecificationOrganisationName
           && contactSpecificationOrganisationName.OrganisationName != (existingItem as ContactSpecificationDtoOrganisationName)?.OrganisationName)
            updatingContext.AddChange(nameof(ApiContactSpecificationOrganisationName.OrganisationName), contactSpecificationOrganisationName.OrganisationName.ToString(), (existingItem as ContactSpecificationDtoOrganisationName)?.OrganisationName.ToString());
        
        if(entity is ApiContactSpecificationPersonalName contactSpecificationPersonalName
           && contactSpecificationPersonalName.PersonalName != (existingItem as ContactSpecificationDtoPersonalName)?.PersonalName)
            updatingContext.AddChange(nameof(ApiContactSpecificationPersonalName.PersonalName), contactSpecificationPersonalName.PersonalName.ToString(), (existingItem as ContactSpecificationDtoPersonalName)?.PersonalName.ToString());
        
        if(entity is ApiContactSpecificationPhoneNumber contactSpecificationPhoneNumber
           && contactSpecificationPhoneNumber.PhoneNumber.PhoneNumberText != (existingItem as ContactSpecificationDtoPhoneNumber)?.PhoneNumber.PhoneNumberText)
            updatingContext.AddChange(nameof(ApiContactSpecificationPhoneNumber.PhoneNumber), contactSpecificationPhoneNumber.PhoneNumber.PhoneNumberText, (existingItem as ContactSpecificationDtoPhoneNumber)?.PhoneNumber.PhoneNumberText);
        
        if(entity is ApiContactSpecificationPostalAddress contactSpecificationPostalAddress
           && contactSpecificationPostalAddress.PostalAddress.ToString() != (existingItem as ContactSpecificationDtoPostalAddress)?.PostalAddress.ToString())
            updatingContext.AddChange(nameof(ApiContactSpecificationPostalAddress.PostalAddress), contactSpecificationPostalAddress.PostalAddress.ToString(), (existingItem as ContactSpecificationDtoPostalAddress)?.PostalAddress.ToString());
        
        if(entity is ApiContactSpecificationBankAccount contactSpecificationBankAccount
           && contactSpecificationBankAccount.BankAccount.ToString() != (existingItem as ContactSpecificationDtoBankAccount)?.BankAccount.ToString())
          updatingContext.AddChange(nameof(ApiContactSpecificationBankAccount.BankAccount), contactSpecificationBankAccount.BankAccount.ToString(), (existingItem as ContactSpecificationDtoBankAccount)?.BankAccount.ToString());
        
        if(entity is ApiContactSpecificationWebsite contactSpecificationWebsite
           && contactSpecificationWebsite.Website.ToString() != (existingItem as ContactSpecificationDtoWebsite)?.Website.ToString())
          updatingContext.AddChange(nameof(ApiContactSpecificationWebsite.Website), contactSpecificationWebsite.Website.ToString(), (existingItem as ContactSpecificationDtoWebsite)?.Website.ToString());

        if (entity is ApiContactSpecificationPaypal contactSpecificationPaypal)
        {
          if (contactSpecificationPaypal.PaypalAddress.ToString() != (existingItem as ContactSpecificationDtoPaypal)?.PaypalAddress.ToString())
              updatingContext.AddChange(nameof(ApiContactSpecificationPaypal.PaypalAddress), contactSpecificationPaypal.PaypalAddress.ToString(), (existingItem as ContactSpecificationDtoPaypal)?.PaypalAddress.ToString());
          
          if (contactSpecificationPaypal.PaypalMeAddress.ToString() != (existingItem as ContactSpecificationDtoPaypal)?.PaypalMeAddress.ToString())
              updatingContext.AddChange(nameof(ApiContactSpecificationPaypal.PaypalMeAddress), contactSpecificationPaypal.PaypalMeAddress.ToString(), (existingItem as ContactSpecificationDtoPaypal)?.PaypalMeAddress.ToString());
        }
    }
}
