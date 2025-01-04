import { Component } from '@angular/core';
import { ProjectFilteringComponent } from '../project-filtering/project-filtering.component';
import { ProjectListComponent } from '../project-list/project-list.component';

@Component({
  selector: 'app-project-section',
  imports: [ProjectFilteringComponent, ProjectListComponent],
  templateUrl: './project-section.component.html',
  styleUrl: './project-section.component.scss'
})
export class ProjectSectionComponent {

}
