import { Component, inject } from '@angular/core';
import { LanguageService } from '../../../../core/services/language-service.service';
import {
  GraphicSustainableProjectsComponent
} from "../../../../shared/components/graphic-sustainable-projects/graphic-sustainable-projects.component";
import {
  GraphicDialogueAndDiscussionComponent
} from "../../../../shared/components/graphic-dialogue-and-discussion/graphic-dialogue-and-discussion.component";
import {
  GraphicTackleAndJoinComponent
} from "../../../../shared/components/graphic-tackle-and-join/graphic-tackle-and-join.component";
import {GraphicLetsgoComponent} from "../../../../shared/components/graphic-letsgo/graphic-letsgo.component";
import {GraphicLetsstartComponent} from "../../../../shared/components/graphic-letsstart/graphic-letsstart.component";
import {
  GraphicGoodLifeForAllComponent
} from "../../../../shared/components/graphic-good-life-for-all/graphic-good-life-for-all.component";
import {IconCloudComponent} from "../../../../shared/components/icon-cloud/icon-cloud.component";
import {IconStarComponent} from "../../../../shared/components/icon-star/icon-star.component";
import {IconRainbowComponent} from "../../../../shared/components/icon-rainbow/icon-rainbow.component";
import {IconWallComponent} from "../../../../shared/components/icon-wall/icon-wall.component";
import {IconMountainComponent} from "../../../../shared/components/icon-mountain/icon-mountain.component";
import {
  IconThreeHatsTiltedComponent
} from "../../../../shared/components/icon-three-hats-tilted/icon-three-hats-tilted.component";
import {IconSpiraleComponent} from "../../../../shared/components/icon-spirale/icon-spirale.component";

@Component({
  selector: 'app-welcome-logo',
  imports: [
    GraphicSustainableProjectsComponent,
    GraphicDialogueAndDiscussionComponent,
    GraphicTackleAndJoinComponent,
    GraphicLetsgoComponent,
    GraphicLetsstartComponent,
    GraphicGoodLifeForAllComponent,
    IconCloudComponent,
    IconStarComponent,
    IconRainbowComponent,
    IconWallComponent,
    IconMountainComponent,
    IconThreeHatsTiltedComponent,
    IconSpiraleComponent
  ],
  templateUrl: './welcome-logo.component.html',
  styleUrl: './welcome-logo.component.scss'
})
export class WelcomeLogoComponent {
  languageService = inject(LanguageService);
  get currentLanguage(){
    return this.languageService.currentLanguageCode;
  }
}
