import { ApplicationModelsApiModelsApiContactSpecificationBankAccount } from "../../../server/model/applicationModelsApiModelsApiContactSpecificationBankAccount";
import { ApplicationModelsApiModelsApiContactSpecificationPaypal } from "../../../server/model/applicationModelsApiModelsApiContactSpecificationPaypal";
import { ApplicationModelsApiModelsApiContactSpecificationTypes } from "../../../server/model/applicationModelsApiModelsApiContactSpecificationTypes";
import { ApplicationModelsApiModelsApiContactSpecificationWebsite } from "../../../server/model/applicationModelsApiModelsApiContactSpecificationWebsite";
import { ObjectCreator } from "../../../shared/tools/object-creator";

export declare type ContactSpecificationType = "bankAccount" | "paypalAccount" | "website";
export class ContactSpecification{
    entityId: null | string = null;
    contactSpecificationType: ContactSpecificationType = "bankAccount";
    bankAccountName: string = "";
    bankAccountIban: string = "";
    bankAccountBic: string = "";
    bankAccountReference: string = "";
    paypalAddress: string = "";
    paypalMeAddress: string = "";
    website: string = "";    

    toContactSpecification(){
        switch(this.contactSpecificationType){
            case "bankAccount":
                return ObjectCreator.Create<ApplicationModelsApiModelsApiContactSpecificationBankAccount>({
                    classType: ApplicationModelsApiModelsApiContactSpecificationTypes.BankAccount,
                    bankAccount: {
                        accountName: this.bankAccountName,
                        bic: {
                            bicName: this.bankAccountBic
                        },
                        iban: {
                            ibanName: this.bankAccountIban
                        },
                        reference: this.bankAccountReference
                    }
                });
            case "paypalAccount":
                return ObjectCreator.Create<ApplicationModelsApiModelsApiContactSpecificationPaypal>({
                    classType: ApplicationModelsApiModelsApiContactSpecificationTypes.Paypal,
                    paypalAddress: {
                        mail: this.paypalAddress
                    },
                    paypalMeAddress: {
                        rawUrl: this.paypalMeAddress
                    }
                });
            case "website":
                return ObjectCreator.Create<ApplicationModelsApiModelsApiContactSpecificationWebsite>({
                    classType: ApplicationModelsApiModelsApiContactSpecificationTypes.Website,
                    website: {
                        rawUrl: this.website
                    }
                });
        }
    }
    private static getEmpty(type: ContactSpecificationType){
        const result = new ContactSpecification();
        result.contactSpecificationType = type;
        return result;
    }
    static fromContactSpecificationPaypal(contactSpecificationPaypal: ApplicationModelsApiModelsApiContactSpecificationPaypal){
        const result = this.getEmpty("paypalAccount");
        result.entityId = contactSpecificationPaypal.entityId ?? null;
        result.paypalAddress = contactSpecificationPaypal.paypalAddress?.mail ?? "";
        result.paypalMeAddress = contactSpecificationPaypal.paypalMeAddress?.rawUrl ?? "";
        return result;
    }

    static fromContactSpecificationWebsite(contactSpecificationWebsite: ApplicationModelsApiModelsApiContactSpecificationWebsite){
        const result = this.getEmpty("website");
        result.entityId = contactSpecificationWebsite.entityId ?? null;
        result.website = contactSpecificationWebsite.website?.rawUrl ?? "";
        return result;
    }

    static fromContactSpecificationBankAccount(contactSpecificationBankAccount: ApplicationModelsApiModelsApiContactSpecificationBankAccount){
        const result = this.getEmpty("bankAccount");
        result.entityId = contactSpecificationBankAccount.entityId ?? null;
        result.bankAccountReference = contactSpecificationBankAccount.bankAccount?.reference ?? "";
        result.bankAccountName = contactSpecificationBankAccount.bankAccount?.accountName ?? "";
        result.bankAccountBic = contactSpecificationBankAccount.bankAccount?.bic?.bicName ?? "";
        result.bankAccountIban = contactSpecificationBankAccount.bankAccount?.iban?.ibanName ?? "";
        return result;
    }
}
