import { DomainEnumsGraphicsType } from "../../server/model/domainEnumsGraphicsType";

export class UploadedImage{
    readonly file: File;
    readonly src: string;
    isLogo: boolean = false;
    isMainImage: boolean = false;
    constructor(file: File){
        this.file = file;
        this.src = URL.createObjectURL(file);
    }

    getType(): DomainEnumsGraphicsType{
        return this.isLogo ? "Logo" : (this.isMainImage ? "Header" : "Additional")
    }

    getBase64(removePrefix: boolean = true): Promise<string>{
        const reader = new FileReader();
        reader.readAsDataURL(this.file);
        return new Promise(resolve => {
            reader.onloadend = () => {
                let result = reader.result?.toString() ?? "";
                if(removePrefix){
                    const firstComma = result.indexOf(",");
                    if(firstComma >= 0 && (firstComma + 1) < result.length){
                        result = result.substring(firstComma+1);
                    }
                }
                resolve(result);
            };
        });
    }
}