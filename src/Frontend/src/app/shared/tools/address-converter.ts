import { DomainDataTypesPostalAddress } from "../../server/model/domainDataTypesPostalAddress";

export class AddressConverter{
    static TransformAddressStringToApiAddress(addressString: string): DomainDataTypesPostalAddress{
        //todo
        return {
            addressLine1: addressString,
            addressLine2: "",
            addressLine3: "",
            addressLine4: "",
            addressLine5: "",
            addressLine6: "",
        }
    }
    static TransformLocationNameStringToApiAddress(addressString: string): DomainDataTypesPostalAddress{
        // todo
        return {
            addressLine1: addressString,
            addressLine2: "",
            addressLine3: "",
            addressLine4: "",
            addressLine5: "",
            addressLine6: "",
        }
    }

    static getShortName(address: DomainDataTypesPostalAddress): string{
        //todo
        return address.addressLine1 ?? "";
    }
    
    static GetAddressFromApiAddress(postalAddress: DomainDataTypesPostalAddress | null): string {
        return postalAddress?.addressLine1 ?? "";
//todo
    }

    static GetRegionFromApiAddress(postalAddress: DomainDataTypesPostalAddress | null): string {
        return postalAddress?.addressLine1 ?? "";
//todo
    }
}