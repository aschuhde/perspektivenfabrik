import { Component, model } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { provideLuxonDateAdapter } from '@angular/material-luxon-adapter';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { DateTime } from 'luxon';

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
  selector: 'app-date-picker-range',
  imports: [MatFormFieldModule, MatInputModule, MatDatepickerModule, FormsModule],
  templateUrl: './date-picker-range.component.html',
  styleUrl: './date-picker-range.component.scss',
  providers: [provideLuxonDateAdapter(DATE_FORMAT_DATE)]
})
export class DatePickerRangeComponent {
  readonly startDate = model.required<DateTime | null>();
  readonly endDate = model.required<DateTime | null>();
}
