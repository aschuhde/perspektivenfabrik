import { Component, HostBinding, inject, input, PLATFORM_ID } from '@angular/core';
import { LanguageSwitchComponent } from '../language-switch/language-switch.component';
import { TranslateModule } from '@ngx-translate/core';
import { UserAreaComponent } from '../user-area/user-area.component';
import {HomeRouteNames} from "../../../features/home/home-route-names";
import { isPlatformBrowser } from '@angular/common';

@Component({
  selector: 'app-navigation',
  imports: [LanguageSwitchComponent, TranslateModule, UserAreaComponent],
  templateUrl: './navigation.component.html',
  styleUrl: './navigation.component.scss'
})
export class NavigationComponent {
  aboutUsUrl = HomeRouteNames.AboutUsUrl();
  missionUrl = HomeRouteNames.OurMissionUrl();
  aboutUsIsExpanded = false;
  platformId = inject(PLATFORM_ID);
  constructor() {
    if(isPlatformBrowser(this.platformId)) {
      document.addEventListener('click', (e) => {
        const target = e.target as HTMLElement;
        if (!target.closest('.about-us-button')) {
          this.aboutUsIsExpanded = false;
        }
      });
    }
  }
  purple = input(false);

  @HostBinding('class') get class() {
    return this.purple() ? "purpleStyle" : "";
  }
  
  toggleAboutUs(){
    this.aboutUsIsExpanded = !this.aboutUsIsExpanded;
  }
}
