import { Provider } from "@angular/core";
import { LuxonDateAdapter, MAT_LUXON_DATE_ADAPTER_OPTIONS } from "@angular/material-luxon-adapter";
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE, MatDateFormats } from "@angular/material/core";
import {LanguageService} from "../../core/services/language-service.service";

export const DATE_FORMAT_DATE_DE = {
    parse: {
        dateInput: 'dd.MM.yyyy',
    },
    display: {
        dateInput: 'dd.MM.yyyy',
        monthYearLabel: 'dd.MM.yyyy',
        dateA11yLabel: 'dd.MM.yyyy',
        monthYearA11yLabel: 'dd.MM.yyyy',
    },
};

export const DATE_FORMAT_DATE_IT = {
    parse: {
        dateInput: 'dd/MM/yyyy',
    },
    display: {
        dateInput: 'dd/MM/yyyy',
        monthYearLabel: 'dd/MM/yyyy',
        dateA11yLabel: 'dd/MM/yyyy',
        monthYearA11yLabel: 'dd/MM/yyyy',
    },
};
export const DATE_FORMAT_MONTH_DE = {
    parse: {
        dateInput: 'dd.MM.yyyy',
    },
    display: {
        dateInput: 'MMMM yyyy',
        monthYearLabel: 'MMMM yyyy',
        dateA11yLabel: 'MMMM yyyy',
        monthYearA11yLabel: 'MMMM yyyy',
    },
};

export const DATE_FORMAT_MONTH_IT = {
    parse: {
        dateInput: 'dd/MM/yyyy',
    },
    display: {
        dateInput: 'MMMM yyyy',
        monthYearLabel: 'MMMM yyyy',
        dateA11yLabel: 'MMMM yyyy',
        monthYearA11yLabel: 'MMMM yyyy',
    },
};

export function provideLuxonDateAdapterFullDate(): Provider[] {
    return provideLuxonDateAdapter(DATE_FORMAT_DATE_DE, DATE_FORMAT_DATE_IT);
}
export function provideLuxonDateAdapterMonth(): Provider[] {
    return provideLuxonDateAdapter(DATE_FORMAT_MONTH_DE, DATE_FORMAT_MONTH_IT);
}
export function provideLuxonDateAdapter(formatsDe: MatDateFormats, formatsIt: MatDateFormats): Provider[]{
    return [
        {provide: MAT_DATE_LOCALE, deps: [LanguageService], useFactory: (languageService: LanguageService) => {
                if(languageService.currentLanguageCode === "it"){
                    return "it-IT";
                }
                return "de-DE";
        }},
        {
            provide: DateAdapter,
            useClass: LuxonDateAdapter,
            deps: [MAT_DATE_LOCALE, MAT_LUXON_DATE_ADAPTER_OPTIONS],
        },
        { provide: MAT_DATE_FORMATS, deps: [LanguageService], useFactory: (languageService: LanguageService) => {
            if(languageService.currentLanguageCode === "it"){
                return formatsIt;
            }
            return formatsDe;
        }},
    ];
}