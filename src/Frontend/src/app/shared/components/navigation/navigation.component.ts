import { Component } from '@angular/core';
import { LanguageSwitchComponent } from '../language-switch/language-switch.component';
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'app-navigation',
  imports: [LanguageSwitchComponent, TranslateModule],
  templateUrl: './navigation.component.html',
  styleUrl: './navigation.component.scss'
})
export class NavigationComponent {
  constructor() {
    
  }
}
