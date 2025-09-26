import { Component, inject, input } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-speech-bubble',
  imports: [],
  templateUrl: './speech-bubble.component.html',
  styleUrl: './speech-bubble.component.scss'
})
export class SpeechBubbleComponent {
  translateService = inject(TranslateService);
  get language(){
    return this.translateService.currentLang;
  }
}
