import { DomainDataTypesPostalAddress } from "../../server/model/domainDataTypesPostalAddress";

export class AddressConverter{
    static TransformAddressStringToApiAddress(addressString: string, locationDisplayName: string): DomainDataTypesPostalAddress{
        return {
            addressText: addressString,
            addressDisplayName: locationDisplayName
        }
    }
    static TransformLocationNameStringToApiAddress(addressString: string, locationDisplayName: string): DomainDataTypesPostalAddress{
        return {
            addressText: addressString,
            addressDisplayName: locationDisplayName
        }
    }

    static getShortName(address: DomainDataTypesPostalAddress): string{
        return address?.addressDisplayName ?? "";
    }
}