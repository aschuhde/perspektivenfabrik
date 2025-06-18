import { Component } from '@angular/core';
import {MatIconModule} from "@angular/material/icon";
import { RestrictedRouteNames } from '../../../features/restricted/restricted-route-names';

@Component({
  selector: 'app-user-area',
  imports: [MatIconModule],
  templateUrl: './user-area.component.html',
  styleUrl: './user-area.component.scss'
})
export class UserAreaComponent {
  routeUserArea= RestrictedRouteNames.MyProjectsUrl()
}
