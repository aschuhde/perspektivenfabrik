import { Component, inject, makeStateKey, PLATFORM_ID, REQUEST, TransferState } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import {Language} from "../../../core/types/general-types";
import {DOCUMENT, isPlatformServer } from '@angular/common';

const LANGUAGE_KEY = makeStateKey<Language>('language');
const LANGUAGE_COOKIE_NAME = 'preferred-language';

@Component({
  selector: 'app-language-switch',
  imports: [],
  templateUrl: './language-switch.component.html',
  styleUrl: './language-switch.component.scss'
})
export class LanguageSwitchComponent {
  translateService = inject(TranslateService)
  currentLanguageDisplayName: string = "DE";
  currentLanguageCode: Language = "de";
  platformId = inject(PLATFORM_ID)
  transferState = inject(TransferState)
  request = inject(REQUEST);
  document = inject(DOCUMENT);
  
  ngOnInit(){
    
    if (isPlatformServer(this.platformId)) {
      // Server-side language detection
      const headers = (this.request?.headers as any) as { [key: string]: string};
      let serverLang = this.parseCookies(headers["cookie"] ?? "")?.[LANGUAGE_COOKIE_NAME];
      if(!serverLang){
        const acceptLanguage = this.request?.headers.get('accept-language') ?? "";
        serverLang = this.getPreferredLanguage(acceptLanguage) ?? "";
      }
      if (this.isValidLanguage(serverLang ?? "")) {
        this.switchTo(serverLang as Language);
      }
      this.transferState.set(LANGUAGE_KEY, serverLang);
    } else {
      const transferredLang = this.transferState.get(LANGUAGE_KEY, null);
      const preferredLangBrowser = window.localStorage.getItem(LANGUAGE_COOKIE_NAME);
      const browserLang = this.translateService.getBrowserLang();

      const preferredLang = transferredLang || preferredLangBrowser || browserLang || 'de';

      if (this.isValidLanguage(preferredLang)) {
        this.switchTo(preferredLang as Language);
      }
    }
  }
  private getPreferredLanguage(acceptLanguage: string) {
    const languages = acceptLanguage.split(',')
        .map(lang => lang.split(';')[0])
        .map(lang => lang.toLowerCase().substring(0, 2));

    for (const lang of languages) {
      if (this.isValidLanguage(lang)) {
        return lang;
      }
    }
    return null;
  }

  private isValidLanguage(lang: string): boolean {
    return ["de", "it"].includes(lang);
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

  private parseCookies(cookieHeader: string = ''): { [key: string]: string } {
    return cookieHeader.split(';').reduce((cookies, cookie) => {
      const [name, value] = cookie.trim().split('=');
      cookies[name] = value;
      return cookies;
    }, {} as { [key: string]: string });
  }
  
  private setLanguageCookie(language: Language) {
    // Set cookie with a 1-year expiry
    const oneYear = 365 * 24 * 60 * 60 * 1000;
    const expires = new Date(Date.now() + oneYear).toUTCString();
    this.document.cookie = `${LANGUAGE_COOKIE_NAME}=${language}; expires=${expires}; path=/; SameSite=Lax`;
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
