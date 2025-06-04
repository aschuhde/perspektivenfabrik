import { Component, inject } from '@angular/core';
import {LanguageService} from "../../../core/services/language-service.service";

@Component({
  selector: 'app-graphic-good-life-for-all',
  imports: [],
  templateUrl: './graphic-good-life-for-all.component.html',
  styleUrl: './graphic-good-life-for-all.component.scss'
})
export class GraphicGoodLifeForAllComponent {
  languageService = inject(LanguageService);
  get currentLanguage(){
    return this.languageService.currentLanguageCode;
  }
}
