import { Component, HostBinding, input } from '@angular/core';
import { NavigationComponent } from '../navigation/navigation.component';

@Component({
  selector: 'app-navigation-bar-single',
  imports: [NavigationComponent],
  templateUrl: './navigation-bar-single.component.html',
  styleUrl: './navigation-bar-single.component.scss'
})
export class NavigationBarSingleComponent {
  purple = input(false);

  @HostBinding('class') get class() {
    return this.purple() ? "purpleStyle" : "";
  }
}
