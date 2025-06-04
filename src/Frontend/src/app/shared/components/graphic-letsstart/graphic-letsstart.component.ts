import { Component, inject } from '@angular/core';
import {LanguageService} from "../../../core/services/language-service.service";

@Component({
  selector: 'app-graphic-letsstart',
  imports: [],
  templateUrl: './graphic-letsstart.component.html',
  styleUrl: './graphic-letsstart.component.scss'
})
export class GraphicLetsstartComponent {
  languageService = inject(LanguageService);
  get currentLanguage(){
    return this.languageService.currentLanguageCode;
  }
}
