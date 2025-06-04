import { Component, inject } from '@angular/core';
import {LanguageService} from "../../../core/services/language-service.service";

@Component({
  selector: 'app-graphic-letsgo',
  imports: [],
  templateUrl: './graphic-letsgo.component.html',
  styleUrl: './graphic-letsgo.component.scss'
})
export class GraphicLetsgoComponent {
  languageService = inject(LanguageService);
  get currentLanguage(){
    return this.languageService.currentLanguageCode;
  }
}
