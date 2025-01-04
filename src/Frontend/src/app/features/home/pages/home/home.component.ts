import { Component } from '@angular/core';
import { WelcomeSectionComponent } from '../../components/welcome-section/welcome-section.component';
import { MotivationSectionComponent } from '../../components/motivation-section/motivation-section.component';
import { ProjectSectionComponent } from '../../components/project-section/project-section.component';

@Component({
    selector: 'app-home',
    imports: [WelcomeSectionComponent, MotivationSectionComponent, ProjectSectionComponent],
    templateUrl: './home.component.html',
    styleUrl: './home.component.scss'
})
export class HomeComponent {

}
