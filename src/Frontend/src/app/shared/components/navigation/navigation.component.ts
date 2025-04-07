import { Component } from '@angular/core';
import { LanguageSwitchComponent } from '../language-switch/language-switch.component';
import { TranslateModule } from '@ngx-translate/core';
import { UserAreaComponent } from '../user-area/user-area.component';

@Component({
  selector: 'app-navigation',
  imports: [LanguageSwitchComponent, TranslateModule, UserAreaComponent],
  templateUrl: './navigation.component.html',
  styleUrl: './navigation.component.scss'
})
export class NavigationComponent {
  constructor() {
    
  }
}
