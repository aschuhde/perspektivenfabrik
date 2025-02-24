import {Injectable} from "@angular/core";

declare type LocaleCode = "en-EN" | "de-DE" | "it-IT";
@Injectable({
    providedIn: "root"
})
export class LocaleDataProvider{
    constructor(){

    }
    locale: LocaleCode = "de-DE"
    dateTimeFormat: string = "dd.MM.yyyy HH:mm";
    dateFormat: string = "dd.MM.yyyy";
}