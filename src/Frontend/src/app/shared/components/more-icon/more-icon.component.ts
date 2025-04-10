import {Component, model} from '@angular/core';

@Component({
  selector: 'app-more-icon',
  imports: [],
  templateUrl: './more-icon.component.html',
  styleUrl: './more-icon.component.scss'
})
export class MoreIconComponent {
  count = model.required<number>();
  tooltipContent = model.required<string>();
}
