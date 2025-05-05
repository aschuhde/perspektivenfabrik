import {Component, input} from '@angular/core';
import {MatFormField, MatLabel} from "@angular/material/form-field";
import {MatSelect} from "@angular/material/select";
import {FormsModule} from "@angular/forms";
import {MatInput} from "@angular/material/input";
import {MatIcon} from "@angular/material/icon";
import { RestrictedRouteNames } from '../../../restricted/restricted-route-names';
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'app-project-filtering',
  imports: [
    MatFormField,
    MatLabel,
    MatSelect,
    FormsModule,
    MatInput,
    MatIcon,
    TranslateModule
  ],
  templateUrl: './project-filtering.component.html',
  styleUrl: './project-filtering.component.scss'
})
export class ProjectFilteringComponent {
  type = input<"home" | "user-area">("home")
  newProjectUrl = RestrictedRouteNames.CreateProjectUrl();
}
