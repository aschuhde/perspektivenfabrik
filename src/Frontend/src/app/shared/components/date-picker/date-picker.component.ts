import { Component, model } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { provideLuxonDateAdapter } from '@angular/material-luxon-adapter';
import { DateTime } from "luxon";

export const DATE_FORMAT_DATE = {
  parse: {
    dateInput: 'dd.MM.yyyy',
  },
  display: {
    dateInput: 'dd.MM.yyyy',
    monthYearLabel: 'dd.MM.yyyy',
    dateA11yLabel: 'dd.MM.yyyy',
    monthYearA11yLabel: 'dd.MM.yyyy',
  },
};


@Component({
  selector: 'app-date-picker',
  imports: [MatFormFieldModule, MatInputModule, MatDatepickerModule, FormsModule],
  templateUrl: './date-picker.component.html',
  styleUrl: './date-picker.component.scss',
  providers: [provideLuxonDateAdapter(DATE_FORMAT_DATE)]
})
export class DatePickerComponent {
  readonly date = model.required<DateTime | null>();
}
  
