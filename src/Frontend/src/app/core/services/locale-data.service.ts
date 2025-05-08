import {inject, Injectable} from "@angular/core";
import { LanguageService } from "./language-service.service";

export declare type LocaleCode = "en-EN" | "de-DE" | "it-IT";
@Injectable({
    providedIn: "root"
})
export class LocaleDataProvider{
    languageService = inject(LanguageService)
    constructor(){

    }
    get locale(): LocaleCode {
        if(this.languageService.currentLanguageCode === "it"){
            return "it-IT";
        }
        return "de-DE";
    }
    get dateTimeFormat() {
        if(this.languageService.currentLanguageCode === "it"){
            return "dd/MM/yyyy HH:mm";
        }
        return "dd.MM.yyyy HH:mm"
    }
    get dateFormat() {
        if(this.languageService.currentLanguageCode === "it"){
            return "dd/MM/yyyy";
        }
        return "dd.MM.yyyy";
    }
}