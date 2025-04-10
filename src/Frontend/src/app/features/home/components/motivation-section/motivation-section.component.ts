import { Component } from '@angular/core';
import { RestrictedRouteNames } from '../../../restricted/restricted-route-names';

@Component({
  selector: 'app-motivation-section',
  imports: [],
  templateUrl: './motivation-section.component.html',
  styleUrl: './motivation-section.component.scss'
})
export class MotivationSectionComponent {
  newProjectUrl = RestrictedRouteNames.CreateProjectUrl();

}
