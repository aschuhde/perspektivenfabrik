import { Language } from "../../core/types/general-types";
import { DomainDataTypesPostalAddress } from "../../server/model/domainDataTypesPostalAddress";
import {TranslationValue} from "../models/translation-value";
import {stringEmptyPropagate} from "./null-tools";

export class AddressConverter{
    static TransformAddressStringToApiAddress(addressString: string, locationDisplayName: string, addressStringTranslations: TranslationValue[], locationDisplayNameTranslations: TranslationValue[], mainLanguage: Language): DomainDataTypesPostalAddress{
        const result = {
            addressText: addressString || addressStringTranslations.length > 0 ? addressString : locationDisplayName,
            addressDisplayName: locationDisplayName || locationDisplayNameTranslations.length > 0 ? locationDisplayName : addressString,
            addressDisplayNameTranslations: locationDisplayName || locationDisplayNameTranslations.length > 0 ? locationDisplayNameTranslations : addressStringTranslations,
            addressTextTranslations: addressString || addressStringTranslations.length > 0 ? addressStringTranslations : locationDisplayNameTranslations
        }

        return {
            addressText: TranslationValue.getTranslationIfExist(result.addressText, result.addressTextTranslations, mainLanguage),
            addressDisplayName: TranslationValue.getTranslationIfExist(result.addressDisplayName, result.addressDisplayNameTranslations, mainLanguage),
            addressDisplayNameTranslations: TranslationValue.toApiTranslationValues(result.addressDisplayNameTranslations),
            addressTextTranslations: TranslationValue.toApiTranslationValues(result.addressTextTranslations)
        }
    }
    static TransformLocationNameStringToApiAddress(addressString: string, locationDisplayName: string, addressStringTranslations: TranslationValue[], locationDisplayNameTranslations: TranslationValue[], mainLanguage: Language): DomainDataTypesPostalAddress{

        const result = {
            addressText: addressString || addressStringTranslations.length > 0 ? addressString : locationDisplayName,
            addressDisplayName: locationDisplayName || locationDisplayNameTranslations.length > 0 ? locationDisplayName : addressString,
            addressDisplayNameTranslations: locationDisplayName || locationDisplayNameTranslations.length > 0 ? locationDisplayNameTranslations : addressStringTranslations,
            addressTextTranslations: addressString || addressStringTranslations.length > 0 ? addressStringTranslations : locationDisplayNameTranslations
        }
        
        return {
            addressText: TranslationValue.getTranslationIfExist(result.addressText, result.addressTextTranslations, mainLanguage),
            addressDisplayName: TranslationValue.getTranslationIfExist(result.addressDisplayName, result.addressDisplayNameTranslations, mainLanguage),
            addressDisplayNameTranslations: TranslationValue.toApiTranslationValues(result.addressDisplayNameTranslations),
            addressTextTranslations: TranslationValue.toApiTranslationValues(result.addressTextTranslations)
        }
    }

    static getShortName(address: DomainDataTypesPostalAddress, language: Language): string{
        const displayNameTranslation = address.addressDisplayNameTranslations?.find(x => x.languageCode == language);
        if(displayNameTranslation && displayNameTranslation.value){
            return displayNameTranslation.value;
        }
        const addressTextTranslation = address.addressTextTranslations?.find(x => x.languageCode == language);
        if(addressTextTranslation && addressTextTranslation.value){
            return addressTextTranslation.value;
        }
        return stringEmptyPropagate(address?.addressDisplayName, address?.addressText ?? "");
    }
}