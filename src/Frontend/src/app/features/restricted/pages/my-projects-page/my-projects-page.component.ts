import { Component } from '@angular/core';
import {UserAreaNavigationComponent} from "../../components/user-area-navigation/user-area-navigation.component";
import {
  NavigationBarFullComponent
} from "../../../../shared/components/navigation-bar-full/navigation-bar-full.component";
import {ProjectSectionComponent} from "../../../home/components/project-section/project-section.component";
import {FooterComponent} from "../../../home/components/footer/footer.component";

@Component({
  selector: 'app-my-projects-page',
  imports: [
    UserAreaNavigationComponent,
    NavigationBarFullComponent,
    ProjectSectionComponent,
    FooterComponent
  ],
  templateUrl: './my-projects-page.component.html',
  styleUrl: './my-projects-page.component.scss'
})
export class MyProjectsPageComponent {

}
