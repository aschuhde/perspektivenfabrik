import { ApplicationModelsApiModelsApiContactSpecificationBankAccount } from "../../../server/model/applicationModelsApiModelsApiContactSpecificationBankAccount";
import { ApplicationModelsApiModelsApiContactSpecificationPaypal } from "../../../server/model/applicationModelsApiModelsApiContactSpecificationPaypal";
import { ApplicationModelsApiModelsApiContactSpecificationTypes } from "../../../server/model/applicationModelsApiModelsApiContactSpecificationTypes";
import { ApplicationModelsApiModelsApiContactSpecificationWebsite } from "../../../server/model/applicationModelsApiModelsApiContactSpecificationWebsite";
import { ObjectCreator } from "../../../shared/tools/object-creator";
import {TranslationValue} from "../../../shared/models/translation-value";
import {Language} from "../../../core/types/general-types";

export declare type ContactSpecificationType = "bankAccount" | "paypalAccount" | "website";
export class ContactSpecification{
    entityId: null | string = null;
    contactSpecificationType: ContactSpecificationType = "bankAccount";
    bankAccountName: string = "";
    bankAccountNameTranslations: TranslationValue[] = [];
    bankAccountIban: string = "";
    bankAccountBic: string = "";
    bankAccountReference: string = "";
    bankAccountReferenceTranslations: TranslationValue[] = [];
    paypalAddress: string = "";
    paypalAddressTranslations: TranslationValue[] = [];
    paypalMeAddress: string = "";
    paypalMeAddressTranslations: TranslationValue[] = [];
    website: string = "";    
    websiteTranslations: TranslationValue[] = [];

    toContactSpecification(){
        switch(this.contactSpecificationType){
            case "bankAccount":
                return ObjectCreator.Create<ApplicationModelsApiModelsApiContactSpecificationBankAccount>({
                    classType: ApplicationModelsApiModelsApiContactSpecificationTypes.BankAccount,
                    bankAccount: {
                        accountName: this.bankAccountName,
                        accountNameTranslations: TranslationValue.toApiTranslationValues(this.bankAccountNameTranslations),
                        bic: {
                            bicName: this.bankAccountBic
                        },
                        iban: {
                            ibanName: this.bankAccountIban
                        },
                        reference: this.bankAccountReference,
                        referenceTranslations: TranslationValue.toApiTranslationValues(this.bankAccountReferenceTranslations),
                    }
                });
            case "paypalAccount":
                return ObjectCreator.Create<ApplicationModelsApiModelsApiContactSpecificationPaypal>({
                    classType: ApplicationModelsApiModelsApiContactSpecificationTypes.Paypal,
                    paypalAddress: {
                        mail: this.paypalAddress,
                        mailTranslations: TranslationValue.toApiTranslationValues(this.paypalAddressTranslations)
                    },
                    paypalMeAddress: {
                        rawUrl: this.paypalMeAddress,
                        urlTranslations: TranslationValue.toApiTranslationValues(this.paypalMeAddressTranslations)
                    }
                });
            case "website":
                return ObjectCreator.Create<ApplicationModelsApiModelsApiContactSpecificationWebsite>({
                    classType: ApplicationModelsApiModelsApiContactSpecificationTypes.Website,
                    website: {
                        rawUrl: this.website,
                        urlTranslations: TranslationValue.toApiTranslationValues(this.websiteTranslations)
                    }
                });
        }
    }
    private static getEmpty(type: ContactSpecificationType){
        const result = new ContactSpecification();
        result.contactSpecificationType = type;
        return result;
    }
    static fromContactSpecificationPaypal(contactSpecificationPaypal: ApplicationModelsApiModelsApiContactSpecificationPaypal, mainLanguage: Language){
        const result = this.getEmpty("paypalAccount");
        result.entityId = contactSpecificationPaypal.entityId ?? null;
        result.paypalMeAddressTranslations = TranslationValue.arrayFromApiTranslationValues(contactSpecificationPaypal.paypalMeAddress?.urlTranslations ?? []);
        result.paypalAddressTranslations = TranslationValue.arrayFromApiTranslationValues(contactSpecificationPaypal.paypalAddress?.mailTranslations ?? []);
        result.paypalAddress = TranslationValue.getTranslationIfExist(contactSpecificationPaypal.paypalAddress?.mail ?? "", result.paypalAddressTranslations, mainLanguage);
        result.paypalMeAddress = TranslationValue.getTranslationIfExist(contactSpecificationPaypal.paypalMeAddress?.rawUrl ?? "", result.paypalMeAddressTranslations, mainLanguage);
        return result;
    }

    static fromContactSpecificationWebsite(contactSpecificationWebsite: ApplicationModelsApiModelsApiContactSpecificationWebsite, mainLanguage: Language){
        const result = this.getEmpty("website");
        result.entityId = contactSpecificationWebsite.entityId ?? null;
        result.websiteTranslations = TranslationValue.arrayFromApiTranslationValues(contactSpecificationWebsite.website?.urlTranslations ?? []);
        result.website = TranslationValue.getTranslationIfExist(contactSpecificationWebsite.website?.rawUrl ?? "", result.websiteTranslations, mainLanguage);   
        return result;
    }

    static fromContactSpecificationBankAccount(contactSpecificationBankAccount: ApplicationModelsApiModelsApiContactSpecificationBankAccount, mainLanguage: Language){
        const result = this.getEmpty("bankAccount");
        result.entityId = contactSpecificationBankAccount.entityId ?? null;
        result.bankAccountReferenceTranslations = TranslationValue.arrayFromApiTranslationValues(contactSpecificationBankAccount.bankAccount?.referenceTranslations ?? []);
        result.bankAccountNameTranslations = TranslationValue.arrayFromApiTranslationValues(contactSpecificationBankAccount.bankAccount?.accountNameTranslations ?? []);
        result.bankAccountReference = TranslationValue.getTranslationIfExist(contactSpecificationBankAccount.bankAccount?.reference ?? "", result.bankAccountReferenceTranslations, mainLanguage);
        result.bankAccountName = TranslationValue.getTranslationIfExist(contactSpecificationBankAccount.bankAccount?.accountName ?? "", result.bankAccountNameTranslations, mainLanguage);
        result.bankAccountBic = contactSpecificationBankAccount.bankAccount?.bic?.bicName ?? "";
        result.bankAccountIban = contactSpecificationBankAccount.bankAccount?.iban?.ibanName ?? "";         
        return result;
    }
}
