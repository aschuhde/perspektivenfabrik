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

  static fromLocationSpecification(location: ApplicationModelsApiModelsApiLocationSpecification) {
    const result = new LocationInput();
    if(location.classType === ApplicationModelsApiModelsApiLocationSpecificationTypes.Address){
      result.locationType = "address";
      result.locationAddress = AddressConverter.GetAddressFromApiAddress((location as ApplicationModelsApiModelsApiLocationSpecificationAddress)?.postalAddress ?? null)
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
      result.locationName = AddressConverter.GetRegionFromApiAddress((location as ApplicationModelsApiModelsApiLocationSpecificationAddress)?.postalAddress ?? null)
    }
    else{
      return null;
    }
    return result;
  }
}