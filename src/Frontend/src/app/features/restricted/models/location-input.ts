import { ApplicationModelsApiModelsApiLocationSpecification } from "../../../server/model/applicationModelsApiModelsApiLocationSpecification";
import { ApplicationModelsApiModelsApiLocationSpecificationAddress } from "../../../server/model/applicationModelsApiModelsApiLocationSpecificationAddress";
import { ApplicationModelsApiModelsApiLocationSpecificationCoordinates } from "../../../server/model/applicationModelsApiModelsApiLocationSpecificationCoordinates";
import { ApplicationModelsApiModelsApiLocationSpecificationRemote } from "../../../server/model/applicationModelsApiModelsApiLocationSpecificationRemote";
import { ApplicationModelsApiModelsApiLocationSpecificationTypes } from "../../../server/model/applicationModelsApiModelsApiLocationSpecificationTypes";
import { AddressConverter } from "../../../shared/tools/address-converter";
import { CoordinatesConverter } from "../../../shared/tools/coordinates-converter";
import { ObjectCreator } from "../../../shared/tools/object-creator";
import {TranslationValue} from "../../../shared/models/translation-value";
import {
    ApplicationModelsApiModelsApiLocationSpecificationEntireProvince
} from "../../../server/model/applicationModelsApiModelsApiLocationSpecificationEntireProvince";
import {
    ApplicationModelsApiModelsApiLocationSpecificationName
} from "../../../server/model/applicationModelsApiModelsApiLocationSpecificationName";
import {Language} from "../../../core/types/general-types";

export declare type LocationType =  "unkown" | "remote" | "name" | "address" | "coordinates" | "entireProvince"
export class LocationInput{
  locationType: LocationType = "address"
  locationLink: string = ""
    locationLinkTranslations: TranslationValue[] = []
  locationName: string = ""
    locationNameTranslations: TranslationValue[] = []
  locationAddress: string = ""
    locationAddressTranslations: TranslationValue[] = []
  locationDisplayName: string = ""
    locationDisplayNameTranslations: TranslationValue[] = []
  locationAddressDisplayName: string = ""
    locationAddressDisplayNameTranslations: TranslationValue[] = []
  locationCoordinates: string = ""
    entityId: string | null = null
  toLocationSpecification(mainLanguage: Language): ApplicationModelsApiModelsApiLocationSpecification | null {
    switch(this.locationType){
        case "address":
            return this.locationAddress ? ObjectCreator.Create<ApplicationModelsApiModelsApiLocationSpecificationAddress>({
                classType: ApplicationModelsApiModelsApiLocationSpecificationTypes.Address,
                entityId: this.entityId ?? undefined,
                postalAddress: AddressConverter.TransformAddressStringToApiAddress(this.locationAddress, this.locationAddressDisplayName, this.locationAddressTranslations, this.locationAddressDisplayNameTranslations, mainLanguage)
            }) : null;
        case "coordinates":
            return this.locationCoordinates ? ObjectCreator.Create<ApplicationModelsApiModelsApiLocationSpecificationCoordinates>({
                classType: ApplicationModelsApiModelsApiLocationSpecificationTypes.Coordinates,
                entityId: this.entityId ?? undefined,
                coordinates: CoordinatesConverter.TransformCoordinatesStringToApiCoordinates(this.locationCoordinates)
            }) : null;
        case "name":
            return this.locationName ? ObjectCreator.Create<ApplicationModelsApiModelsApiLocationSpecificationName>({
                classType: ApplicationModelsApiModelsApiLocationSpecificationTypes.Name,
                entityId: this.entityId ?? undefined,
                postalAddress: AddressConverter.TransformLocationNameStringToApiAddress(this.locationName, this.locationDisplayName, this.locationNameTranslations, this.locationDisplayNameTranslations, mainLanguage)
            }) : null;
        case "remote":
            return ObjectCreator.Create<ApplicationModelsApiModelsApiLocationSpecificationRemote>({
                classType: ApplicationModelsApiModelsApiLocationSpecificationTypes.Remote,
                entityId: this.entityId ?? undefined,
                link: {
                    rawUrl: TranslationValue.getTranslationIfExist(this.locationLink, this.locationLinkTranslations, mainLanguage),
                    urlTranslations: TranslationValue.toApiTranslationValues(this.locationLinkTranslations)
                }
            });
        case "entireProvince":
            return ObjectCreator.Create<ApplicationModelsApiModelsApiLocationSpecificationEntireProvince>({
                classType: ApplicationModelsApiModelsApiLocationSpecificationTypes.EntireProvince
            });
    }
    return null;
  }

  static fromLocationSpecification(location: ApplicationModelsApiModelsApiLocationSpecification, mainLanguage: Language) {
    const result = new LocationInput();
    result.entityId = location.entityId ?? null;
    if(location.classType === ApplicationModelsApiModelsApiLocationSpecificationTypes.Address){
      result.locationType = "address";
        result.locationAddressDisplayNameTranslations = TranslationValue.arrayFromApiTranslationValues((location as ApplicationModelsApiModelsApiLocationSpecificationAddress)?.postalAddress?.addressDisplayNameTranslations ?? [])
        result.locationAddressTranslations = TranslationValue.arrayFromApiTranslationValues((location as ApplicationModelsApiModelsApiLocationSpecificationAddress)?.postalAddress?.addressTextTranslations ?? [])
        result.locationAddress = TranslationValue.getTranslationIfExist((location as ApplicationModelsApiModelsApiLocationSpecificationAddress)?.postalAddress?.addressText ?? "", result.locationAddressTranslations, mainLanguage)
        result.locationAddressDisplayName = TranslationValue.getTranslationIfExist((location as ApplicationModelsApiModelsApiLocationSpecificationAddress)?.postalAddress?.addressDisplayName ?? "", result.locationAddressDisplayNameTranslations, mainLanguage)
    }
    else if(location.classType === ApplicationModelsApiModelsApiLocationSpecificationTypes.Remote){
      result.locationType = "remote";
      result.locationLinkTranslations = TranslationValue.arrayFromApiTranslationValues((location as ApplicationModelsApiModelsApiLocationSpecificationRemote)?.link?.urlTranslations ?? [])
        result.locationLink = TranslationValue.getTranslationIfExist((location as ApplicationModelsApiModelsApiLocationSpecificationRemote)?.link?.rawUrl ?? "", result.locationLinkTranslations, mainLanguage);
    }
    else if(location.classType === ApplicationModelsApiModelsApiLocationSpecificationTypes.Coordinates){
      result.locationType = "coordinates";
      result.locationCoordinates = CoordinatesConverter.FromApiCoordinates((location as ApplicationModelsApiModelsApiLocationSpecificationCoordinates)?.coordinates ?? null)
    }
    else if(location.classType === ApplicationModelsApiModelsApiLocationSpecificationTypes.Region){
      result.locationType = "name";
        result.locationDisplayNameTranslations = TranslationValue.arrayFromApiTranslationValues((location as ApplicationModelsApiModelsApiLocationSpecificationAddress)?.postalAddress?.addressDisplayNameTranslations ?? [])
        result.locationNameTranslations = TranslationValue.arrayFromApiTranslationValues((location as ApplicationModelsApiModelsApiLocationSpecificationAddress)?.postalAddress?.addressTextTranslations ?? [])
        result.locationName = TranslationValue.getTranslationIfExist((location as ApplicationModelsApiModelsApiLocationSpecificationAddress)?.postalAddress?.addressText ?? "", result.locationNameTranslations, mainLanguage)
        result.locationDisplayName = TranslationValue.getTranslationIfExist((location as ApplicationModelsApiModelsApiLocationSpecificationAddress)?.postalAddress?.addressDisplayName ?? "", result.locationDisplayNameTranslations, mainLanguage)
    }
    else if(location.classType === ApplicationModelsApiModelsApiLocationSpecificationTypes.Name){
        result.locationType = "name";
        result.locationDisplayNameTranslations = TranslationValue.arrayFromApiTranslationValues((location as ApplicationModelsApiModelsApiLocationSpecificationAddress)?.postalAddress?.addressDisplayNameTranslations ?? [])
        result.locationNameTranslations = TranslationValue.arrayFromApiTranslationValues((location as ApplicationModelsApiModelsApiLocationSpecificationAddress)?.postalAddress?.addressTextTranslations ?? [])
        result.locationName = TranslationValue.getTranslationIfExist((location as ApplicationModelsApiModelsApiLocationSpecificationAddress)?.postalAddress?.addressText ?? "", result.locationNameTranslations, mainLanguage)
        result.locationDisplayName = TranslationValue.getTranslationIfExist((location as ApplicationModelsApiModelsApiLocationSpecificationAddress)?.postalAddress?.addressDisplayName ?? "", result.locationDisplayNameTranslations, mainLanguage)
    }
    else if(location.classType === ApplicationModelsApiModelsApiLocationSpecificationTypes.EntireProvince){
        result.locationType = "entireProvince";
    }
    else{
      return null;
    }
    return result;
  }
}