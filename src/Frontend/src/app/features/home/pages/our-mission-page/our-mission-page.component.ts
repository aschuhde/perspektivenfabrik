import { Component } from '@angular/core';
import {OurMissionComponent} from "../../components/our-mission/our-mission.component";
import {
  NavigationBarFullComponent
} from "../../../../shared/components/navigation-bar-full/navigation-bar-full.component";
import {FooterComponent} from "../../components/footer/footer.component";

@Component({
  selector: 'app-our-mission-page',
  imports: [OurMissionComponent,
    NavigationBarFullComponent,
    FooterComponent],
  templateUrl: './our-mission-page.component.html',
  styleUrl: './our-mission-page.component.scss'
})
export class OurMissionPageComponent {

}
