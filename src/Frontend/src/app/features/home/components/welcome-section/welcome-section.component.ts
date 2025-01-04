import { Component } from '@angular/core';
import { WelcomeLogoComponent } from '../welcome-logo/welcome-logo.component';
import { WelcomeTextComponent } from '../welcome-text/welcome-text.component';
import { NavigationBarSingleComponent } from '../../../../shared/components/navigation-bar-single/navigation-bar-single.component';

@Component({
  selector: 'app-welcome-section',
  imports: [WelcomeLogoComponent, WelcomeTextComponent, NavigationBarSingleComponent],
  templateUrl: './welcome-section.component.html',
  styleUrl: './welcome-section.component.scss'
})
export class WelcomeSectionComponent {

}
