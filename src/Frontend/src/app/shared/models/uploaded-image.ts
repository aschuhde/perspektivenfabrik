import { DomainEnumsGraphicsType } from "../../server/model/domainEnumsGraphicsType";
import {
    ApplicationModelsApiModelsApiGraphicsSpecification
} from "../../server/model/applicationModelsApiModelsApiGraphicsSpecification";

export class UploadedImage{
    readonly file: File | null = null;
    src: string = "";
    isLogo: boolean = false;
    isMainImage: boolean = false;
    constructor(file: File | null){
        this.file = file;
        if(file) {
            this.src = URL.createObjectURL(file);
        }
    }

    getType(): DomainEnumsGraphicsType{
        return this.isLogo ? "Logo" : (this.isMainImage ? "Header" : "Additional")
    }

    static fromApi(graphicsSpecification: ApplicationModelsApiModelsApiGraphicsSpecification): UploadedImage{
        const result = new UploadedImage(null);
        result.src = "data:image/png;base64, " + (graphicsSpecification.content?.content ?? "");
        result.isLogo = graphicsSpecification.type == "Logo";
        result.isMainImage = graphicsSpecification.type == "Header"
        return result;
    }
    
    getBase64(removePrefix: boolean = true): Promise<string>{
        if(!this.file){
            return new Promise(resolve => {
                let result = this.src ?? "";
                if(removePrefix){
                    const firstComma = result.indexOf(",");
                    if(firstComma >= 0 && (firstComma + 1) < result.length){
                        result = result.substring(firstComma+1);
                    }
                }
                resolve(result);
            });
        }
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