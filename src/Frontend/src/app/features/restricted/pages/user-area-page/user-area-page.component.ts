import { Component } from '@angular/core';
import {ProjectSectionComponent} from "../../../home/components/project-section/project-section.component";
import {
  NavigationBarFullComponent
} from "../../../../shared/components/navigation-bar-full/navigation-bar-full.component";
import {FooterComponent} from "../../../home/components/footer/footer.component";

@Component({
  selector: 'app-user-area-page',
    imports: [ProjectSectionComponent, NavigationBarFullComponent, FooterComponent],
  templateUrl: './user-area-page.component.html',
  styleUrl: './user-area-page.component.scss'
})
export class UserAreaPageComponent {

}
