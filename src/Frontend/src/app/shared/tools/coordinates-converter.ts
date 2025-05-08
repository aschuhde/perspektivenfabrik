import { DomainDataTypesCoordinates } from "../../server/model/domainDataTypesCoordinates";

export class CoordinatesConverter{
    static TransformCoordinatesStringToApiCoordinates(coordinatesString: string) : DomainDataTypesCoordinates{
        if (!coordinatesString || !coordinatesString.includes(',')) {
            throw new Error('Invalid coordinates format');
        }

        const [lat, lon] = coordinatesString.split(',').map(coord => parseFloat(coord.trim()));

        if (isNaN(lat) || isNaN(lon)) {
            throw new Error('Invalid coordinates values');
        }

        return {lat, lon};
    }

  static FromApiCoordinates(geoCoordinates: DomainDataTypesCoordinates | null) {
    return `${geoCoordinates?.lat},${geoCoordinates?.lon}`;
  }
}