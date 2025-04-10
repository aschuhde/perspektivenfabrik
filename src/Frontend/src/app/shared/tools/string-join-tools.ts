import {LocaleCode} from "../../core/services/locale-data.service";

export function joinWithConjunction(array: string[] | null | undefined, locale: LocaleCode): string {
    let conjunction = "and";
    switch (locale) {
        case "de-DE":
            conjunction = "und";
            break;
        case "it-IT":
            conjunction = "e";
            break;
    }
    if(!array || array.length === 0){
        return ""
    }
    if(array.length === 1){
        return array[0];
    }
    if(array.length === 2){
        return `${array[0]} ${conjunction} ${array[1]}`
    }
    return `${array.slice(0, -1).join(", ")} ${conjunction} ${array[array.length - 1]}`
}