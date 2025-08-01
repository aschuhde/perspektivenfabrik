﻿import {isPlatformServer} from "@angular/common";
import {Language} from "../types/general-types";
import { inject, Injectable, makeStateKey, PLATFORM_ID, REQUEST, TransferState, DOCUMENT } from "@angular/core";
import { TranslateService } from "@ngx-translate/core";


const LANGUAGE_KEY = makeStateKey<Language>('language');
const LANGUAGE_COOKIE_NAME = 'preferred-language';

@Injectable({
    providedIn: "root"
})
export class LanguageService {
    translateService = inject(TranslateService)
    currentLanguageDisplayName: string = "DE";
    currentLanguageCode: Language = "de";
    platformId = inject(PLATFORM_ID)
    transferState = inject(TransferState)
    request = inject(REQUEST);
    document = inject(DOCUMENT);

    constructor() {
        this.detectLanguage();
    }

    detectLanguage(){
        let language = this.getCurrentLanguage();
        if (isPlatformServer(this.platformId)) {
            if(language) {
                this.transferState.set(LANGUAGE_KEY, language);
            }
            if(!this.isValidLanguage(language)) {
                language = "de";
            }
        }else{
            const transferredLang = this.transferState.get(LANGUAGE_KEY, null);
            language = transferredLang || language;
            if(!this.isValidLanguage(language))
                language = "de";
        }
        if (this.isValidLanguage(language ?? "")) {
            this.switchTo(language as Language);
        }
    }
    
    getCurrentLanguage(): Language | null{
        if (isPlatformServer(this.platformId)) {

            let parts = this.request?.url.split('?') ?? [];
            let serverLang = this.parseCookies(this.request?.headers.get('cookie') ?? "")?.[LANGUAGE_COOKIE_NAME];
            if(parts.length > 1){
                let queryLang = new URLSearchParams(parts[1]).get("hl") ?? "";
                if(this.isValidLanguage(queryLang)) {
                    serverLang = queryLang;
                }
            }
            if(!serverLang){
                const acceptLanguage = this.request?.headers.get('accept-language') ?? "";
                serverLang = this.getPreferredLanguage(acceptLanguage) ?? "";
            }
            if(!this.isValidLanguage(serverLang))
                return null;
            
            return serverLang as Language;
        }
        
        const preferredLangBrowser = window.localStorage.getItem(LANGUAGE_COOKIE_NAME);
        const browserLang = this.translateService.getBrowserLang();
        const lang = preferredLangBrowser || browserLang || 'de';
        if(!this.isValidLanguage(lang))
            return "de";
        return lang as Language;
    }
    private getPreferredLanguage(acceptLanguage: string) {
        const languages = acceptLanguage.split(',')
            .map(lang => lang.split(';')[0])
            .map(lang => lang.toLowerCase().substring(0, 2));

        for (const code of languages) {
            let lang = code;
            if(code.toLowerCase().includes("de")){
                lang = "de";
            }
            if(code.toLowerCase().includes("it")){
                lang = "it";
            }             
            if (this.isValidLanguage(lang)) {
                return lang;
            }
        }
        return null;
    }
    switchTo(languageCode: Language){
        if(languageCode === "en"){
            this.switchTo("de");
            return;
        }
        this.currentLanguageCode = languageCode;
        this.currentLanguageDisplayName = this.getDisplayName(languageCode);
        this.translateService.use(languageCode);
        if(!isPlatformServer(this.platformId)) {
            this.setLanguageCookie(languageCode);
            window.localStorage.setItem(LANGUAGE_COOKIE_NAME, languageCode);
        }
        this.updateHeader();
    }

    private parseCookies(cookieHeader: string = ''): { [key: string]: string } {
        return cookieHeader.split(';').reduce((cookies, cookie) => {
            const [name, value] = cookie.trim().split('=');
            cookies[name] = value;
            return cookies;
        }, {} as { [key: string]: string });
    }

    updateHeader(){
        this.document.querySelector("html")?.setAttribute("lang", this.currentLanguageCode);
        this.document.querySelector("meta[name=description]")?.setAttribute("content", this.translateService.instant("meta.description") );
        this.document.querySelector("meta[property='og:description']")?.setAttribute("content", this.translateService.instant("meta.description"));
        this.document.querySelector("meta[name=language]")?.setAttribute("content", this.currentLanguageCode);
    }
    
    private setLanguageCookie(language: Language) {
        // Set cookie with a 1-year expiry
        const oneYear = 365 * 24 * 60 * 60 * 1000;
        const expires = new Date(Date.now() + oneYear).toUTCString();
        this.document.cookie = `${LANGUAGE_COOKIE_NAME}=${language}; expires=${expires}; path=/; SameSite=Lax`;
    }

    private isValidLanguage(lang: string | null): boolean {
        return ["de", "it"].includes(lang ?? "");
    }

    getDisplayName(languageCode: Language){
        switch (languageCode) {
            case "en":
                return "EN";
            case "de":
                return "DE";
            case "it":
                return "IT";
        }
    }
    toggleLanguage() {
        if(this.currentLanguageCode === "en"){
            this.switchTo("de");
            return;
        }else if (this.currentLanguageCode === "de"){
            this.switchTo("it");
            return;
        }
        this.switchTo("de");
    }
    
}