import { Component, HostBinding, input } from '@angular/core';
import { LanguageSwitchComponent } from '../language-switch/language-switch.component';
import { TranslateModule } from '@ngx-translate/core';
import { UserAreaComponent } from '../user-area/user-area.component';
import {HomeRouteNames} from "../../../features/home/home-route-names";

@Component({
  selector: 'app-navigation',
  imports: [LanguageSwitchComponent, TranslateModule, UserAreaComponent],
  templateUrl: './navigation.component.html',
  styleUrl: './navigation.component.scss'
})
export class NavigationComponent {
  aboutUsUrl = HomeRouteNames.AboutUsUrl();
  constructor() {
    
  }
  purple = input(false);

  @HostBinding('class') get class() {
    return this.purple() ? "purpleStyle" : "";
  }
}
