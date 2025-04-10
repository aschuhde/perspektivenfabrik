import { DomainDataTypesCoordinates } from "../../server/model/domainDataTypesCoordinates";

export class CoordinatesConverter{
    static TransformCoordinatesStringToApiCoordinates(coordinatesString: string) : DomainDataTypesCoordinates{
        //todo
        return {
            lat: 0,
            lon: 0
        }
    }

  static FromApiCoordinates(geoCoordinates: DomainDataTypesCoordinates | null) {
    return `${geoCoordinates?.lat},${geoCoordinates?.lon}`;
  }
}