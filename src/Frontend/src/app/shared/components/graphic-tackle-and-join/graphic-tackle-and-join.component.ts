import { Component, inject } from '@angular/core';
import {LanguageService} from "../../../core/services/language-service.service";

@Component({
  selector: 'app-graphic-tackle-and-join',
  imports: [],
  templateUrl: './graphic-tackle-and-join.component.html',
  styleUrl: './graphic-tackle-and-join.component.scss'
})
export class GraphicTackleAndJoinComponent {
  languageService = inject(LanguageService);
  get currentLanguage(){
    return this.languageService.currentLanguageCode;
  }
}
