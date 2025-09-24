import { Component, inject } from '@angular/core';
import { TranslatePipe, TranslateService } from '@ngx-translate/core';
import {IconStarComponent} from "../../../../shared/components/icon-star/icon-star.component";
import {
  IconThreeHatsTiltedComponent
} from "../../../../shared/components/icon-three-hats-tilted/icon-three-hats-tilted.component";
import {LogoComponent} from "../../../../shared/components/logo/logo.component";
import {IconCloudComponent} from "../../../../shared/components/icon-cloud/icon-cloud.component";

@Component({
  selector: 'app-our-mission',
  imports: [TranslatePipe, IconStarComponent, IconThreeHatsTiltedComponent, LogoComponent, IconCloudComponent],
  templateUrl: './our-mission.component.html',
  styleUrl: './our-mission.component.scss'
})
export class OurMissionComponent {
  translateService = inject(TranslateService)
  get language(){
    return this.translateService.currentLang;
  }
}
