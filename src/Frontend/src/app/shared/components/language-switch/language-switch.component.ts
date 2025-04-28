import { Component, inject } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

declare type Language = "en" | "it" | "de";

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
  
  ngOnInit(){
    const preferredLanguage = window.localStorage.getItem("preferred-language");
    const currentLang = this.translateService.currentLang;
    const browserLang = this.translateService.getBrowserLang();
    if(currentLang === "it"){
      this.currentLanguageCode = "it";
    }else if(currentLang === "en"){
      this.currentLanguageCode = "en";
    }else{
      this.currentLanguageCode = "de";
    }
    this.currentLanguageDisplayName = this.getDisplayName(this.currentLanguageCode);
    
    if(preferredLanguage && preferredLanguage !== this.currentLanguageCode
      && ["en", "de", "it"].includes(preferredLanguage)){
      this.switchTo(preferredLanguage as Language);
    }else if(browserLang && browserLang !== this.currentLanguageCode && ["en", "de", "it"].includes(browserLang)){
      this.switchTo(browserLang as Language);
    }
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
  
  switchTo(languageCode: Language){
    if(languageCode === "en"){
      this.switchTo("de");
      return;
    }
    this.currentLanguageCode = languageCode;
    this.currentLanguageDisplayName = this.getDisplayName(languageCode);
    this.translateService.use(languageCode);
    window.localStorage.setItem("preferred-language", this.currentLanguageCode);
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
