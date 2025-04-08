import { ApplicationModelsApiModelsApiLocationSpecification } from "../../../server/model/applicationModelsApiModelsApiLocationSpecification";
import { ApplicationModelsApiModelsApiLocationSpecificationAddress } from "../../../server/model/applicationModelsApiModelsApiLocationSpecificationAddress";
import { ApplicationModelsApiModelsApiLocationSpecificationCoordinates } from "../../../server/model/applicationModelsApiModelsApiLocationSpecificationCoordinates";
import { ApplicationModelsApiModelsApiLocationSpecificationRemote } from "../../../server/model/applicationModelsApiModelsApiLocationSpecificationRemote";
import { ApplicationModelsApiModelsApiLocationSpecificationTypes } from "../../../server/model/applicationModelsApiModelsApiLocationSpecificationTypes";
import { AddressConverter } from "../../../shared/tools/address-converter";
import { CoordinatesConverter } from "../../../shared/tools/coordinates-converter";
import { ObjectCreator } from "../../../shared/tools/object-creator";

export declare type LocationType =  "unkown" | "remote" | "name" | "address" | "coordinates"
export class LocationInput{
  locationType: LocationType = "address"
  locationLink: string = ""
  locationName: string = ""
  locationAddress: string = ""
  locationDisplayName: string = ""
  locationAddressDisplayName: string = ""
  locationCoordinates: string = ""
    entityId: string | null = null
  toLocationSpecification(): ApplicationModelsApiModelsApiLocationSpecification | null {
    switch(this.locationType){
        case "address":
            return this.locationAddress ? ObjectCreator.Create<ApplicationModelsApiModelsApiLocationSpecificationAddress>({
                classType: ApplicationModelsApiModelsApiLocationSpecificationTypes.Address,
                entityId: this.entityId ?? undefined,
                postalAddress: AddressConverter.TransformAddressStringToApiAddress(this.locationAddress, this.locationAddressDisplayName)
            }) : null;
        case "coordinates":
            return this.locationCoordinates ? ObjectCreator.Create<ApplicationModelsApiModelsApiLocationSpecificationCoordinates>({
                classType: ApplicationModelsApiModelsApiLocationSpecificationTypes.Coordinates,
                entityId: this.entityId ?? undefined,
                coordinates: CoordinatesConverter.TransformCoordinatesStringToApiCoordinates(this.locationCoordinates)
            }) : null;
        case "name":
            return this.locationName ? ObjectCreator.Create<ApplicationModelsApiModelsApiLocationSpecificationAddress>({
                classType: ApplicationModelsApiModelsApiLocationSpecificationTypes.Address,
                entityId: this.entityId ?? undefined,
                postalAddress: AddressConverter.TransformLocationNameStringToApiAddress(this.locationName, this.locationDisplayName)
            }) : null;
        case "remote":
            return ObjectCreator.Create<ApplicationModelsApiModelsApiLocationSpecificationRemote>({
                classType: ApplicationModelsApiModelsApiLocationSpecificationTypes.Remote,
                entityId: this.entityId ?? undefined,
                link: {
                    rawUrl: this.locationLink
                }
            });
    }
    return null;
  }

  static fromLocationSpecification(location: ApplicationModelsApiModelsApiLocationSpecification) {
    const result = new LocationInput();
    result.entityId = location.entityId ?? null;
    if(location.classType === ApplicationModelsApiModelsApiLocationSpecificationTypes.Address){
      result.locationType = "address";
      result.locationAddress = (location as ApplicationModelsApiModelsApiLocationSpecificationAddress)?.postalAddress?.addressText ?? ""
      result.locationDisplayName = (location as ApplicationModelsApiModelsApiLocationSpecificationAddress)?.postalAddress?.addressDisplayName ?? ""
    }
    else if(location.classType === ApplicationModelsApiModelsApiLocationSpecificationTypes.Remote){
      result.locationType = "remote";
      result.locationLink = (location as ApplicationModelsApiModelsApiLocationSpecificationRemote)?.link?.rawUrl ?? "";
    }
    else if(location.classType === ApplicationModelsApiModelsApiLocationSpecificationTypes.Coordinates){
      result.locationType = "coordinates";
      result.locationCoordinates = CoordinatesConverter.FromApiCoordinates((location as ApplicationModelsApiModelsApiLocationSpecificationCoordinates)?.coordinates ?? null)
    }
    else if(location.classType === ApplicationModelsApiModelsApiLocationSpecificationTypes.Region){
      result.locationType = "name";
      result.locationName = (location as ApplicationModelsApiModelsApiLocationSpecificationAddress)?.postalAddress?.addressText ?? ""
      result.locationDisplayName = (location as ApplicationModelsApiModelsApiLocationSpecificationAddress)?.postalAddress?.addressDisplayName ?? ""
      
    }
    else{
      return null;
    }
    return result;
  }
}