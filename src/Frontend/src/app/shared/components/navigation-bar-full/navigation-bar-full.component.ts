import { Component } from '@angular/core';
import { NavigationComponent } from '../navigation/navigation.component';
import {HomeRouteNames} from "../../../features/home/home.routes";

@Component({
  selector: 'app-navigation-bar-full',
  imports: [NavigationComponent],
  templateUrl: './navigation-bar-full.component.html',
  styleUrl: './navigation-bar-full.component.scss'
})
export class NavigationBarFullComponent {
  homeUrl = HomeRouteNames.HomeUrl();

}
