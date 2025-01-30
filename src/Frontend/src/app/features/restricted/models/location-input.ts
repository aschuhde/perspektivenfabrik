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
  locationCoordinates: string = ""
  toLocationSpecification(): ApplicationModelsApiModelsApiLocationSpecification | null {
    switch(this.locationType){
        case "address":
            return this.locationAddress ? ObjectCreator.Create<ApplicationModelsApiModelsApiLocationSpecificationAddress>({
                classType: ApplicationModelsApiModelsApiLocationSpecificationTypes.Address,
                postalAddress: AddressConverter.TransformAddressStringToApiAddress(this.locationAddress)
            }) : null;
        case "coordinates":
            return this.locationCoordinates ? ObjectCreator.Create<ApplicationModelsApiModelsApiLocationSpecificationCoordinates>({
                classType: ApplicationModelsApiModelsApiLocationSpecificationTypes.Coordinates,
                coordinates: CoordinatesConverter.TransformCoordinatesStringToApiCoordinates(this.locationCoordinates)
            }) : null;
        case "name":
            return this.locationName ? ObjectCreator.Create<ApplicationModelsApiModelsApiLocationSpecificationAddress>({
                classType: ApplicationModelsApiModelsApiLocationSpecificationTypes.Address,
                postalAddress: AddressConverter.TransformLocationNameStringToApiAddress(this.locationName)
            }) : null;
        case "remote":
            return ObjectCreator.Create<ApplicationModelsApiModelsApiLocationSpecificationRemote>({
                classType: ApplicationModelsApiModelsApiLocationSpecificationTypes.Remote,
                link: {
                    rawUrl: this.locationLink
                }
            });
    }
    return null;
  }    
}