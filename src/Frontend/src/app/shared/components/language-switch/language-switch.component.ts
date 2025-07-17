import { Component, inject, PLATFORM_ID } from '@angular/core';
import { LanguageService } from "../../../core/services/language-service.service";
import { isPlatformBrowser } from '@angular/common';
import { MatIcon } from '@angular/material/icon';


@Component({
  selector: 'app-language-switch',
  imports: [MatIcon],
  templateUrl: './language-switch.component.html',
  styleUrl: './language-switch.component.scss'
})
export class LanguageSwitchComponent {
  languageService = inject(LanguageService)
  languageSwitchShown = false;
  platformId = inject(PLATFORM_ID);

  ngOnInit(){
    this.languageService.detectLanguage();
    if(isPlatformBrowser(this.platformId)) {
      document.addEventListener('click', (e) => {
        const target = e.target as HTMLElement;
        if (!target.closest('app-language-switch')) {
          this.languageSwitchShown = false;
        }
      });
    }
  }

  get currentLanguageDisplayName(){
    return this.languageService.currentLanguageDisplayName;
  }

  get otherLanguageDisplayNameLong(){
    return this.languageService.currentLanguageCode === "de" ? "Italiano" : "Deutsch";
  }

  toggleLanguage() {
    this.languageService.toggleLanguage();

    this.languageSwitchShown = false;
  }

  toggleLanguageSwitch() {
    this.languageSwitchShown = !this.languageSwitchShown;
  }
}
