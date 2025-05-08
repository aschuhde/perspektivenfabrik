import { Component, model } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { DateTime } from "luxon";
import { TranslateModule } from '@ngx-translate/core';
import { provideLuxonDateAdapterFullDate } from '../../tools/language-tools';

@Component({
  selector: 'app-date-picker',
  imports: [MatFormFieldModule, MatInputModule, MatDatepickerModule, FormsModule, TranslateModule],
  templateUrl: './date-picker.component.html',
  styleUrl: './date-picker.component.scss',
  providers: [provideLuxonDateAdapterFullDate()]
})
export class DatePickerComponent {
  readonly date = model.required<DateTime | null>();
}
  
