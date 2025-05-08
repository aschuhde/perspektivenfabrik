import { Component, inject } from '@angular/core';
import { LanguageService } from "../../../core/services/language-service.service";


@Component({
  selector: 'app-language-switch',
  imports: [],
  templateUrl: './language-switch.component.html',
  styleUrl: './language-switch.component.scss'
})
export class LanguageSwitchComponent {
  languageService = inject(LanguageService)

  get currentLanguageDisplayName(){
    return this.languageService.currentLanguageDisplayName;
  }

  toggleLanguage() {
    this.languageService.toggleLanguage();
  }
}
