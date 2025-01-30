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
}