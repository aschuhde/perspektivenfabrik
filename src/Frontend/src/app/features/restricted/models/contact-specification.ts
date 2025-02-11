import { ApplicationModelsApiModelsApiContactSpecificationBankAccount } from "../../../server/model/applicationModelsApiModelsApiContactSpecificationBankAccount";
import { ApplicationModelsApiModelsApiContactSpecificationPaypal } from "../../../server/model/applicationModelsApiModelsApiContactSpecificationPaypal";
import { ApplicationModelsApiModelsApiContactSpecificationTypes } from "../../../server/model/applicationModelsApiModelsApiContactSpecificationTypes";
import { ApplicationModelsApiModelsApiContactSpecificationWebsite } from "../../../server/model/applicationModelsApiModelsApiContactSpecificationWebsite";
import { ObjectCreator } from "../../../shared/tools/object-creator";

export declare type ContactSpecificationType = "bankAccount" | "paypalAccount" | "website";
export class ContactSpecification{
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
}
