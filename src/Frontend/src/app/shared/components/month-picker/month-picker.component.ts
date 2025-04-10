import { Component, model } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { MatDatepicker, MatDatepickerModule } from '@angular/material/datepicker';
import { provideLuxonDateAdapter } from '@angular/material-luxon-adapter';
import { DateTime } from "luxon";

export const DATE_FORMAT_MONTH = {
  parse: {
    dateInput: 'dd.MM.yyyy',
  },
  display: {
    dateInput: 'MMMM yyyy',
    monthYearLabel: 'MMMM yyyy',
    dateA11yLabel: 'MMMM yyyy',
    monthYearA11yLabel: 'MMMM yyyy',
  },
};

@Component({
  selector: 'app-month-picker',
  imports: [MatFormFieldModule, MatInputModule, MatDatepickerModule, FormsModule],
  templateUrl: './month-picker.component.html',
  styleUrl: './month-picker.component.scss',
  providers: [provideLuxonDateAdapter(DATE_FORMAT_MONTH)]
})
export class MonthPickerComponent {
  readonly month = model.required<DateTime | null>();

  setMonthAndYear(monthAndYear: DateTime, datepicker: MatDatepicker<DateTime>) {
    this.month.set(monthAndYear);
    datepicker.close();
  }
}
