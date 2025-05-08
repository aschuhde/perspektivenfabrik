import { DateTime } from "luxon";
import {DomainDataTypesMonth} from "../../server/model/domainDataTypesMonth";
import {parseMoneyWithFallback} from "./parsing";

export class DateTools{
    static ToDateOnlyApiString(date: DateTime | null){
        return date?.toFormat("yyyy-MM-dd") ?? null;
    }
    static ToDateOnlyApiStringNotNull(date: DateTime){
        return date.toFormat("yyyy-MM-dd");
    }
}

export function getMonthName(monthFromOneToTwelve: number, locale: string): string{
    if(monthFromOneToTwelve < 1 || monthFromOneToTwelve > 12){
        return "";
    }

    const germanMonths = [
        "Januar", 
        "Februar", 
        "März", 
        "April", 
        "Mai", 
        "Juni", 
        "Juli", 
        "August", 
        "September", 
        "Oktober", 
        "November", 
        "Dezember"
    ];

    const italianMonths = [
        "Gennaio",
        "Febbraio",
        "Marzo",
        "Aprile",
        "Maggio",
        "Giugno",
        "Luglio",
        "Agosto",
        "Settembre",
        "Ottobre",
        "Novembre",
        "Dicembre"
    ];

    return locale === 'it' ? italianMonths[monthFromOneToTwelve - 1] : germanMonths[monthFromOneToTwelve - 1];
}

export function getLuxonDateTimeFromNullableJsDate(date: Date | null): DateTime | null{
    if(date === null){
        return null;
    }
    return DateTime.fromJSDate(date);
}

export function getLuxonDateTimeFromMonth(month: DomainDataTypesMonth | null) {
    if(!month?.year?.yearNumber || !month?.monthFromOneToTwelve){
        return null;
    }
    return DateTime.fromJSDate(new Date(month.year.yearNumber, month.monthFromOneToTwelve - 1, 1));
}

export function formatDate(value: Date | null, locale: string){
    if(locale === "it"){
        return getLuxonDateTimeFromNullableJsDate(value)?.toFormat("dd/MM/yyyy") ?? "";
    }
    return getLuxonDateTimeFromNullableJsDate(value)?.toFormat("dd.MM.yyyy") ?? "";
}
export function formatTime(value: Date | null, locale: string){
    return getLuxonDateTimeFromNullableJsDate(value)?.toFormat("HH:mm:ss") ?? "";
}