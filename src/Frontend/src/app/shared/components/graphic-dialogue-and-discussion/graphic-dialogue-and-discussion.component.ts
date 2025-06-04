import { Component, inject } from '@angular/core';
import {LanguageService} from "../../../core/services/language-service.service";

@Component({
  selector: 'app-graphic-dialogue-and-discussion',
  imports: [],
  templateUrl: './graphic-dialogue-and-discussion.component.html',
  styleUrl: './graphic-dialogue-and-discussion.component.scss'
})
export class GraphicDialogueAndDiscussionComponent {
  languageService = inject(LanguageService);
  get currentLanguage(){
    return this.languageService.currentLanguageCode;
  }
}
