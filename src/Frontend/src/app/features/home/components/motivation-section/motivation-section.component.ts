import { Component } from '@angular/core';
import { RestrictedRouteNames } from '../../../restricted/restricted-route-names';
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'app-motivation-section',
  imports: [TranslateModule],
  templateUrl: './motivation-section.component.html',
  styleUrl: './motivation-section.component.scss'
})
export class MotivationSectionComponent {
  newProjectUrl = RestrictedRouteNames.CreateProjectUrl();

}
