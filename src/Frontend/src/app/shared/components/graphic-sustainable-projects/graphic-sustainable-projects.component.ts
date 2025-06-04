import { Component, inject } from '@angular/core';
import {LanguageService} from "../../../core/services/language-service.service";

@Component({
  selector: 'app-graphic-sustainable-projects',
  imports: [],
  templateUrl: './graphic-sustainable-projects.component.html',
  styleUrl: './graphic-sustainable-projects.component.scss'
})
export class GraphicSustainableProjectsComponent {
  languageService = inject(LanguageService);
  get currentLanguage(){
    return this.languageService.currentLanguageCode;
  }
}
