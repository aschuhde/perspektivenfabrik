import {Component, input, InputSignal} from '@angular/core';
import { ProjectFilteringComponent } from '../project-filtering/project-filtering.component';
import { ProjectListComponent } from '../project-list/project-list.component';
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'app-project-section',
  imports: [ProjectFilteringComponent, ProjectListComponent, TranslateModule],
  templateUrl: './project-section.component.html',
  styleUrl: './project-section.component.scss'
})
export class ProjectSectionComponent {
  type = input<"home" | "user-area">("home")
}
